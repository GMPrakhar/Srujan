using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using LLVMSharp.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static सृजनParser;

namespace Srujan.Lexer
{

    internal unsafe class CompilerListener : सृजनBaseListener
    {
        private LLVMModuleRef module;
        private unsafe LLVMOpaqueBuilder* builder;
        Dictionary<string, (LLVMTypeRef type, LLVMValueRef value, LLVMValueRef variable)> variables = new Dictionary<string, (LLVMTypeRef, LLVMValueRef, LLVMValueRef)>();
        Dictionary<LLVMTypeRef, string> staticMappingForPrint = new Dictionary<LLVMTypeRef, string>()
        {
            { LLVM.Int32Type(), "%d" },
            { LLVM.Int16Type(), "%c" },
            { LLVM.PointerType(LLVM.Int16Type(), 0), "%s" },

        };

        public unsafe CompilerListener(LLVMModuleRef moduleRef)
        {
            this.module = moduleRef;
            this.builder = LLVM.CreateBuilder();
        }

        public override unsafe void EnterFactor([NotNull] FactorContext context)
        {
        }


        public unsafe override void EnterVariableDeclaration([NotNull] सृजनParser.VariableDeclarationContext context)
        {
            string idString = context.ID().GetText();
            var sp = idString.ToSBytePointer();
            var expression = context.expression().GetText().Replace("\"", "").Replace("'", "");

            LLVMTypeRef typeRef = LLVMTypeRef.Void;
            LLVMValueRef value = LLVM.ConstNull(LLVMTypeRef.Int32);

            LLVMValueRef variable = value;

            switch (context.TYPE().GetText())
            {
                case "अंक": typeRef = LLVM.Int32Type(); value = LLVM.ConstInt(LLVM.Int32Type(), uint.Parse(expression), 0); variable = LLVM.BuildAlloca(this.builder, typeRef, sp); break;
                case "अक्षर": typeRef = LLVM.Int16Type(); value = LLVM.ConstInt(LLVM.Int16Type(),  char.Parse(expression), 0); variable = LLVM.BuildAlloca(this.builder, typeRef, sp); break;
                case "तार": typeRef = LLVM.PointerType(LLVM.Int16Type(), 0); value = LLVM.ConstString(expression.ToSBytePointer(), (uint)Encoding.UTF8.GetByteCount(expression), 0); variable = LLVM.BuildArrayAlloca(this.builder, typeRef, value, sp); break;

                    // Can be exended
            } 

            LLVM.BuildStore(this.builder, value, variable);
            variables.Add(idString, (typeRef, value, variable));
        }

        public override unsafe void EnterPrintStatement([NotNull] सृजनParser.PrintStatementContext context)
        {
            // Get the expression to print
            var expressionText = context.expression().GetText();
            var variableData = variables[expressionText];

            // Convert the pointer value to a string pointer using bitcast
            LLVMTypeRef stringPtrType = LLVM.PointerType(LLVM.Int8Type(), 0); // Assuming the pointer is to an i8*
            LLVMOpaqueValue* stringPtr = LLVM.BuildGlobalStringPtr(this.builder, staticMappingForPrint[variableData.type].ToSBytePointer(), "stringParam".ToSBytePointer());

            LLVMOpaqueValue*[] values = { stringPtr, variableData.type.Kind == LLVMTypeKind.LLVMPointerTypeKind ? variableData.variable : variableData.value };

            // Call printf function
            // Create LLVM IR function prototype for printf
            LLVMOpaqueType*[] printfArgs = { stringPtrType, variableData.type };

            fixed(LLVMOpaqueType**  finalPrintArgs = &(printfArgs[0]))
            {

                LLVMTypeRef printfType = LLVM.FunctionType(LLVM.Int32Type(), finalPrintArgs, 2, 1);
                LLVMValueRef printfFunction = module.GetNamedFunction("printf");

                if (printfFunction.Handle == IntPtr.Zero)
                {
                    printfFunction = LLVM.AddFunction(this.module, "printf".ToSBytePointer(), printfType);
                }

                fixed(LLVMOpaqueValue** finalPrintParams = &(values[0]))
                LLVM.BuildCall2(this.builder, printfType, printfFunction, finalPrintParams, 2, "printfCall".ToSBytePointer());

            }
        }

        public override unsafe void EnterFunction([NotNull] सृजनParser.FunctionContext context)
        {
            // Get function name and return type
            string functionName = context.MAIN()?.GetText() ?? context.functionName().GetText();

            LLVMTypeRef returnType = LLVM.VoidType(); // Assuming the return type is int for simplicity

            // Create function type
            LLVMTypeRef functionType = LLVM.FunctionType(returnType, null, 0, 0);

            // Add function to module
            LLVMValueRef function = LLVM.AddFunction(module, functionName.ToSBytePointer(), functionType);

            // Create entry basic block
            LLVMBasicBlockRef entryBlock = LLVM.AppendBasicBlock(function, "entry".ToSBytePointer());

            // Set builder position to entry block
            LLVM.PositionBuilderAtEnd(builder, entryBlock);

            // Define function body (you would need to implement this based on your language semantics)
            // For example, generate LLVM IR instructions for function body statements

        }

        public override unsafe void ExitFunction([NotNull] सृजनParser.FunctionContext context)
        {
            LLVM.BuildRetVoid(builder);

        }
    }
}
