﻿using Antlr4.Runtime;
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
        public unsafe LLVMOpaqueBuilder* builder;
        Dictionary<string, (LLVMTypeRef type, LLVMValueRef value, LLVMValueRef variable)> variables = new Dictionary<string, (LLVMTypeRef, LLVMValueRef, LLVMValueRef)>();
        Dictionary<LLVMTypeRef, string> staticMappingForPrint = new Dictionary<LLVMTypeRef, string>()
        {
            { LLVM.Int32Type(), "%d" },
            { LLVM.Int16Type(), "%c" },
            { LLVM.DoubleType(), "%.3f" },
            { LLVM.PointerType(LLVM.Int16Type(), 0), "%s" },

        };

        public unsafe CompilerListener(LLVMModuleRef moduleRef)
        {
            this.module = moduleRef;
            this.builder = LLVM.CreateBuilder();
        }

        LLVMValueRef EvaluateFactor(सृजनParser.FactorContext context)
        {
            if (context.expression() != null)
            {
                return EvaluateExpression(context.expression());
            }

            if (context.ID() != null)
            {
                var variableContext = variables[context.ID().GetText()];
                var tempStore = LLVM.BuildLoad2(builder, variableContext.type, variableContext.variable, "loadtmp".ToSBytePointer());
                return tempStore;
            }

            if (context.INT() != null)
            {
                return LLVM.ConstInt(LLVM.Int32Type(), uint.Parse(context.INT().GetText()), 0);
            }

            if (context.CHAR() != null)
            {
                return LLVM.ConstInt(LLVM.Int16Type(), char.Parse(context.CHAR().GetText()), 0);
            }

            if(context.DECIMAL() != null)
            {
                return LLVM.ConstReal(LLVM.DoubleType(), double.Parse(context.DECIMAL().GetText()));
            }

            if (context.STRING() != null)
            {
                var stringData = context.STRING().GetText().Replace("\"", "").Replace("'", "");
                return LLVM.ConstString(stringData.ToSBytePointer(), (uint)Encoding.UTF8.GetByteCount(stringData), 0);
            }

            return null;
        }

        private LLVMValueRef EvaluateTerm(TermContext termContext)
        {
            var allFactors = termContext.factor();
            var firstFactor = allFactors[0];
            LLVMValueRef left = EvaluateFactor(firstFactor);
            LLVMValueRef finalValue = left;
            for (int i = 1; i < allFactors.Length; i++)
            {
                var right = EvaluateFactor(allFactors[i]);
                if (left.TypeOf == LLVM.DoubleType() || right.TypeOf == LLVM.DoubleType())
                {
                    var tmpVariable = LLVM.BuildAlloca(builder, LLVM.DoubleType(), "casttmp".ToSBytePointer());
                    if (left.TypeOf == LLVM.Int32Type())
                    {
                        left = LLVM.ConstReal(LLVM.DoubleType(), LLVM.ConstIntGetSExtValue(left));
                    }
                    if(right.TypeOf == LLVM.Int32Type())
                    {
                        right = LLVM.ConstReal(LLVM.DoubleType(), LLVM.ConstIntGetSExtValue(right));
                    }
                }

                if (termContext.MULTIPLY()?.Length != 0)
                {
                    if(left.TypeOf == LLVM.Int32Type() && right.TypeOf == LLVM.Int32Type())
                    {
                        finalValue = LLVM.BuildMul(this.builder, left, right, "multmp".ToSBytePointer());
                    }
                    else
                    {
                        finalValue = LLVM.BuildFMul(this.builder, left, right, "multmp".ToSBytePointer());
                    }
                }
                else
                {
                    if (left.TypeOf == LLVM.Int32Type() && right.TypeOf == LLVM.Int32Type())
                    {
                        finalValue = LLVM.BuildUDiv(this.builder, left, right, "divtmp".ToSBytePointer());
                    }
                    else
                    {
                        finalValue = LLVM.BuildFDiv(this.builder, left, right, "divtmp".ToSBytePointer());
                    }
                }

                firstFactor = allFactors[i];
                left = EvaluateFactor(firstFactor);
            }

            return finalValue;
        }

        public LLVMValueRef EvaluateExpression(ExpressionContext expressionContext)
        {
            var allTerms = expressionContext.term();
            var firstTerm = allTerms[0];
            LLVMValueRef left = EvaluateTerm(firstTerm);
            LLVMValueRef finalValue = left;
            for (int i = 1; i < allTerms.Length; i++)
            {
                var right = EvaluateTerm(allTerms[i]);
                if (left.TypeOf == LLVM.DoubleType() || right.TypeOf == LLVM.DoubleType())
                {
                    if (left.TypeOf == LLVM.Int32Type())
                        left = LLVM.ConstReal(LLVM.DoubleType(), LLVM.ConstIntGetSExtValue(left));
                    if (right.TypeOf == LLVM.Int32Type())
                        right = LLVM.ConstReal(LLVM.DoubleType(), LLVM.ConstIntGetSExtValue(right));
                }

                if (expressionContext.PLUS()?.Length != 0)
                {
                    if(left.TypeOf == LLVM.Int32Type() && right.TypeOf == LLVM.Int32Type())
                    {
                        finalValue = LLVM.BuildAdd(this.builder, left, right, "addtmp".ToSBytePointer());
                    }
                    else
                    {
                        finalValue = LLVM.BuildFAdd(this.builder, left, right, "addtmp".ToSBytePointer());
                    }
                }
                else
                {
                    if(left.TypeOf == LLVM.Int32Type() && right.TypeOf == LLVM.Int32Type())
                    {
                        finalValue = LLVM.BuildSub(this.builder, left, right, "subtmp".ToSBytePointer());
                    }
                    else
                    {
                        finalValue = LLVM.BuildFSub(this.builder, left, right, "subtmp".ToSBytePointer());
                    }
                }

                firstTerm = allTerms[i];
                left = EvaluateTerm(firstTerm);
            }

            return finalValue;
        }

        public unsafe override void EnterAssignment([NotNull] सृजनParser.AssignmentContext context)
        {
            string idString = context.ID().GetText();
            var sp = idString.ToSBytePointer();
            var value = EvaluateExpression(context.expression());
            var variableContext = variables[idString];
            var variable = variableContext.variable;

            if (variableContext.type == LLVM.DoubleType() && value.TypeOf == LLVM.Int32Type())
            {
                value = LLVM.ConstReal(LLVM.DoubleType(), LLVM.ConstIntGetSExtValue(value));
            }

            LLVM.BuildStore(this.builder, value, variable);
            variables[idString] = (variables[idString].type, value, variable);
        }


        public unsafe override void EnterVariableDeclaration([NotNull] सृजनParser.VariableDeclarationContext context)
        {
            string idString = context.ID().GetText();
            var sp = idString.ToSBytePointer();
            var value = EvaluateExpression(context.expression());

            LLVMTypeRef typeRef = LLVMTypeRef.Void;

            LLVMValueRef variable = value;

            switch (context.TYPE().GetText())
            {
                case "अंक": typeRef = LLVM.Int32Type(); variable = LLVM.BuildAlloca(this.builder, typeRef, sp); break;
                case "अक्षर": typeRef = LLVM.Int16Type();variable = LLVM.BuildAlloca(this.builder, typeRef, sp); break;
                case "तार": typeRef = LLVM.PointerType(LLVM.Int16Type(), 0); variable = LLVM.BuildArrayAlloca(this.builder, typeRef, value, sp); break;
                case "दशमलव": typeRef = LLVM.DoubleType(); variable = LLVM.BuildAlloca(this.builder, typeRef, sp); break;

                    // Can be exended
            } 

            LLVM.BuildStore(this.builder, value, variable);
            variables.Add(idString, (typeRef, value, variable));
        }

        public override unsafe void EnterPrintStatement([NotNull] सृजनParser.PrintStatementContext context)
        {
            var evaluatedExpression = EvaluateExpression(context.expression());
            var valueType = evaluatedExpression.TypeOf;

            if(evaluatedExpression.IsConstantString)
            {
                valueType = LLVM.PointerType(LLVM.Int16Type(), 0);
                // convert LLVM.ConstString to a pointer
                evaluatedExpression = LLVM.BuildGlobalStringPtr(this.builder, evaluatedExpression.GetAsString(out _).ToSBytePointer(), "stringParam".ToSBytePointer());
            }

            // Convert the pointer value to a string pointer using bitcast
            LLVMTypeRef stringPtrType = LLVM.PointerType(LLVM.Int8Type(), 0); // Assuming the pointer is to an i8*
            LLVMOpaqueValue* stringPtr = LLVM.BuildGlobalStringPtr(this.builder, staticMappingForPrint[valueType].ToSBytePointer(), "stringParam".ToSBytePointer());

            LLVMOpaqueValue*[] values = { stringPtr, evaluatedExpression};

            // Call printf function
            // Create LLVM IR function prototype for printf
            LLVMOpaqueType*[] printfArgs = { stringPtrType, valueType };

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
