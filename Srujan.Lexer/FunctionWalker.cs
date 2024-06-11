using Antlr4.Runtime.Tree;
using LLVMSharp;
using LLVMSharp.Interop;
using Srujan.Lexer;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static सृजनParser;

namespace Srujan
{
    internal unsafe class FunctionWalker
    {
        private unsafe LLVMOpaqueBuilder* builder;
        private readonly CompilerListener listener;
        private ParseTreeWalker parentWalker;

        public FunctionWalker(LLVMOpaqueBuilder* builder, CompilerListener listener, सृजनParseTreeWalker parentWalker)
        {
            this.builder = builder;
            this.listener = listener;
            this.parentWalker = parentWalker;
        }

        public unsafe void EnterFunction([NotNull] FunctionContext context)
        {

            // Get function name and return type
            bool isMainFunction = context.MAIN()?.GetText() != null;
            string functionName = isMainFunction ? "main" : context.functionName().GetText();

            var block = LLVM.GetInsertBlock(builder);
            var allTypes = context.TYPE();
            var allArgumentNames = context.ID();
            var returnType = allTypes[0].GetText();
            LLVMTypeRef functionType;

            if (allTypes.Length > 1)
            {
                var allOpaqueTypes = allTypes.Skip(1).Select(x => this.listener.stringTypeToLLVMType[x.GetText()]).ToArray();

                LLVMOpaqueType*[] opaqueTypes = new LLVMOpaqueType*[allOpaqueTypes.Count()];
                for (int i = 0; i < allOpaqueTypes.Length; i++)
                {
                    opaqueTypes[i] = allOpaqueTypes[i];
                }


                fixed (LLVMOpaqueType** types = &(opaqueTypes[0]))
                {
                    functionType = LLVM.FunctionType(this.listener.stringTypeToLLVMType[returnType], types, (uint)opaqueTypes.Length, 0);
                }
            }
            else
            {
                functionType = LLVM.FunctionType(this.listener.stringTypeToLLVMType[returnType], null, 0, 0);
            }

                    // Add function to module
            LLVMValueRef function = LLVM.AddFunction(this.listener.module, functionName.ToSBytePointer(), functionType);

            this.listener.variables.Add(functionName, (functionType, function, function));

            var functionStart = LLVM.AppendBasicBlock(function, (isMainFunction ? "entry" : functionName + "start").ToSBytePointer());

            LLVM.PositionBuilderAtEnd(builder, functionStart);

            if(allTypes.Length > 1)
            {
                // Add all the function arguments as variable with names. the function arguments will have name as % + index of argument
                for (int i = 0; i < allTypes.Length - 1; i++)
                {
                    LLVMValueRef argument = LLVM.GetParam(function, (uint)i);
                    var argumentName = allArgumentNames[i].GetText();
                    LLVMValueRef variable = LLVM.BuildAlloca(this.builder, argument.TypeOf, argumentName.ToSBytePointer());
                    LLVM.BuildStore(this.builder, argument, variable);

                    this.listener.variables[argumentName] = (this.listener.stringTypeToLLVMType[allTypes[i + 1].GetText()], argument, variable);
                }
            }

            foreach (var statement in context.statement())
            {
                this.parentWalker.Walk(this.listener, statement);
            }
                
        }
    }
}
