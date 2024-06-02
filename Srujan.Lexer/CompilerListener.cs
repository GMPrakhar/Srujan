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
        public unsafe LLVMBuilderRef builder;
        
        Dictionary<string, (LLVMTypeRef type, LLVMValueRef value, LLVMValueRef variable)> variables = new Dictionary<string, (LLVMTypeRef, LLVMValueRef, LLVMValueRef)>();
        Dictionary<LLVMTypeRef, string> staticMappingForPrint = new Dictionary<LLVMTypeRef, string>()
        {
            { LLVM.Int32Type(), "%d" },
            { LLVM.Int16Type(), "%c" },
            { LLVM.DoubleType(), "%.3f" },
            { LLVM.PointerType(LLVM.Int16Type(), 0), "%s" },

        };

        IDictionary<string, LLVMTypeRef> stringTypeToLLVMType = new Dictionary<string, LLVMTypeRef>()
        {
            { "अंक", LLVM.Int32Type() },
            { "अक्षर", LLVM.Int16Type() },
            { "तार", LLVM.PointerType(LLVM.Int16Type(), 0) },
            { "दशमलव", LLVM.DoubleType() }
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
                if(variableContext.type.Kind == LLVMTypeKind.LLVMPointerTypeKind)
                {
                    // the variable is a string variable, load using getelementptr in bounds

                    var indices = new LLVMOpaqueValue*[] { LLVM.ConstInt(LLVM.Int32Type(), (uint)0, 0) };
                    LLVMValueRef variable;
                    fixed (LLVMOpaqueValue** indicesPointer = &(indices[0]))
                    {
                        return LLVM.BuildGEP2(builder, LLVM.PointerType(variableContext.value.TypeOf, 0), variableContext.variable, indicesPointer, 0, "tempString".ToSBytePointer());
                    }
                }

                return LLVM.BuildLoad2(builder, variableContext.type, variableContext.variable, "loadtmp".ToSBytePointer());
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

            if (context.arrayAccess() != null)
            {
                return GetArrayElement(context.arrayAccess());
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
                UpcastToDecimalIfMismatch(ref left, ref right);

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
                else if (termContext.DIVIDE()?.Length != 0)
                {
                    if (left.TypeOf == LLVM.Int32Type() && right.TypeOf == LLVM.Int32Type())
                    {
                        finalValue = LLVM.BuildSDiv(this.builder, left, right, "divtmp".ToSBytePointer());
                    }
                    else
                    {
                        finalValue = LLVM.BuildFDiv(this.builder, left, right, "divtmp".ToSBytePointer());
                    }
                }
                else
                {
                    // Generate code for modulo operation

                    if (left.TypeOf == LLVM.Int32Type() && right.TypeOf == LLVM.Int32Type())
                    {
                        finalValue = LLVM.BuildSRem(this.builder, left, right, "modtmp".ToSBytePointer());
                    }
                    else
                    {
                        finalValue = LLVM.BuildFRem(this.builder, left, right, "modtmp".ToSBytePointer());
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
                UpcastToDecimalIfMismatch(ref left, ref right);

                if (expressionContext.PLUS()?.Length != 0)
                {
                    if (left.TypeOf == LLVM.Int32Type() && right.TypeOf == LLVM.Int32Type())
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
                    if (left.TypeOf == LLVM.Int32Type() && right.TypeOf == LLVM.Int32Type())
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

        private static void UpcastToDecimalIfMismatch(ref LLVMValueRef left, ref LLVMValueRef right)
        {
            if (left.TypeOf == LLVM.DoubleType() || right.TypeOf == LLVM.DoubleType())
            {
                if (left.TypeOf == LLVM.Int32Type())
                    left = LLVM.ConstReal(LLVM.DoubleType(), LLVM.ConstIntGetSExtValue(left));
                if (right.TypeOf == LLVM.Int32Type())
                    right = LLVM.ConstReal(LLVM.DoubleType(), LLVM.ConstIntGetSExtValue(right));
            }
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
            LLVMValueRef value = null;
            if (context.expression() != null)
            {
                value = EvaluateExpression(context.expression());
            }

            var elementType = context.TYPE().GetText();

            LLVMTypeRef typeRef = stringTypeToLLVMType[elementType];

            LLVMValueRef variable;

            if (value != null && typeRef != value.TypeOf && typeRef.Kind != LLVMTypeKind.LLVMPointerTypeKind)
            {
                throw new InvalidOperationException($"Value of type {value.TypeOf} is not assignable to {elementType}.");
            }

            if (typeRef.Kind == LLVMTypeKind.LLVMPointerTypeKind)
            {
                variable = LLVM.BuildArrayAlloca(this.builder, value.TypeOf, value, sp);
            }
            else
            {
                variable = LLVM.BuildAlloca(this.builder, typeRef, sp);
                if (value != null)
                {
                    LLVM.BuildStore(this.builder, value, variable);
                }
            }

            variables.Add(idString, (typeRef, value, variable));
        }

        public override unsafe void EnterArrayDeclaration([NotNull] ArrayDeclarationContext context)
        {
            string idString = context.ID().GetText();
            var sp = idString.ToSBytePointer();
            var arrayType = context.TYPE();

            var elementTypeValue = stringTypeToLLVMType[arrayType.GetText()];

            var arraySize = EvaluateExpression(context.expression());

            if(arraySize.TypeOf != LLVM.Int32Type())
            {
                throw new InvalidOperationException("Array size must be an integer");
            }

            long arraySizeValue = LLVM.ConstIntGetSExtValue(arraySize);
            var arrayTypeValue = LLVM.ArrayType(elementTypeValue, (uint)arraySizeValue);

            if (arraySizeValue <= 0)
            {
                throw new InvalidOperationException("Array size must be greater than 0");
            }

            var variable = LLVM.BuildArrayAlloca(builder, arrayTypeValue, null, sp);
            variables.Add(idString, (arrayTypeValue, null, variable));
        }

        public override unsafe void EnterArrayInitialization([NotNull] ArrayInitializationContext context)
        {
            string idString = context.ID().GetText();
            var sp = idString.ToSBytePointer();
            var arrayTypeValue = variables[idString].type;
            var elementTypeValue = arrayTypeValue.ElementType;

            var expressions = context.expression();
            for (int i = 0; i < expressions.Length; i++)
            {
                var assignmentValue = EvaluateExpression(expressions[i]);
                if (assignmentValue.TypeOf != elementTypeValue)
                {
                    throw new InvalidOperationException("Array initialization value must be of the same type as the array");
                }

                var indices = new LLVMOpaqueValue*[] { LLVM.ConstInt(LLVM.Int32Type(), (uint)i, 0) };

                fixed (LLVMOpaqueValue** indicesPointer = &(indices[0]))
                {
                    var variablePointer = variables[idString].variable;
                    var variable = LLVM.BuildGEP2(builder, arrayTypeValue, variablePointer, indicesPointer, 1, sp);
                    var store = LLVM.BuildStore(builder, assignmentValue, variable);
                }
            }
        }

        public override unsafe void EnterArrayAssignment([NotNull] ArrayAssignmentContext context)
        {
            string idString = context.ID().GetText();
            var sp = idString.ToSBytePointer();
            var expressions = context.expression();
            var index = EvaluateExpression(expressions[0]);

            var assignmentValue = EvaluateExpression(expressions[1]);

            if (index.TypeOf != LLVM.Int32Type())
            {
                throw new InvalidOperationException("Array index must be an integer");
            }

            // store value in array
            var variableContext = variables[idString];
            var arrayTypeValue = variableContext.type;
            var variablePointer = variableContext.variable;

            var indices = new LLVMOpaqueValue*[] { index };

            fixed (LLVMOpaqueValue** indicesPointer = &(indices[0]))
            {
                var variable = LLVM.BuildGEP2(builder, arrayTypeValue, variablePointer, indicesPointer, 1, sp);
                var store = LLVM.BuildStore(builder, assignmentValue, variable);
            }
        }

        private LLVMOpaqueValue* GetArrayElement(ArrayAccessContext context)
        {
            string idString = context.ID().GetText();
            var sp = idString.ToSBytePointer();
            var index = EvaluateExpression(context.expression());

            if (index.TypeOf != LLVM.Int32Type())
            {
                throw new InvalidOperationException("Array index must be an integer");
            }

            var variableContext = variables[idString];
            var arrayTypeValue = variableContext.type;
            var variablePointer = variableContext.variable;

            var indices = new LLVMOpaqueValue*[] { index };

            fixed (LLVMOpaqueValue** indicesPointer = &(indices[0]))
            {
                var variable = LLVM.BuildGEP2(builder, arrayTypeValue, variablePointer, indicesPointer, 1, sp);
                return LLVM.BuildLoad2(builder, arrayTypeValue.ElementType, variable, "loadtmp".ToSBytePointer());
            }
        }

        public override unsafe void EnterInputStatement([NotNull] InputStatementContext context)
        {
            // Generate code
            var idString = context.ID().GetText();
            var variableContext = variables[idString];
            var variable = variableContext.variable;
            var type = variableContext.type;

            // use scanf to read input
            LLVMOpaqueValue* stringPtr = LLVM.BuildGlobalStringPtr(this.builder, staticMappingForPrint[type].ToSBytePointer(), "stringParam".ToSBytePointer());
            LLVMOpaqueValue*[] values = { stringPtr, variable };

            // Create LLVM IR function prototype for scanf
            LLVMOpaqueType*[] scanfArgs = { LLVM.PointerType(LLVM.Int8Type(), 0), LLVM.PointerType(type, 0) };

            fixed (LLVMOpaqueType** finalScanfArgs = &(scanfArgs[0]))
            {
                LLVMTypeRef scanfType = LLVM.FunctionType(LLVM.Int32Type(), finalScanfArgs, 2, 1);
                LLVMValueRef scanfFunction = module.GetNamedFunction("scanf");

                if (scanfFunction.Handle == IntPtr.Zero)
                {
                    scanfFunction = LLVM.AddFunction(this.module, "scanf".ToSBytePointer(), scanfType);
                }

                fixed (LLVMOpaqueValue** finalScanfParams = &(values[0]))
                {
                    LLVM.BuildCall2(this.builder, scanfType, scanfFunction, finalScanfParams, 2, "scanfCall".ToSBytePointer());
                }
            }
        }

        public override unsafe void EnterPrintStatement([NotNull] सृजनParser.PrintStatementContext context)
        {
            var evaluatedExpression = EvaluateExpression(context.expression());
            var newline = context.NEWLINE() != null ? "\n" : null;
            var valueType = evaluatedExpression.TypeOf;

            if(evaluatedExpression.IsConstantString)
            {
                valueType = LLVM.PointerType(LLVM.Int16Type(), 0);
                // convert LLVM.ConstString to a pointer
                evaluatedExpression = LLVM.BuildGlobalStringPtr(this.builder, evaluatedExpression.GetAsString(out _).ToSBytePointer(), "stringParam".ToSBytePointer());
            }else if(evaluatedExpression.TypeOf.Kind == LLVMTypeKind.LLVMArrayTypeKind || evaluatedExpression.TypeOf.Kind == LLVMTypeKind.LLVMPointerTypeKind)
            {
                valueType = LLVM.PointerType(LLVM.Int16Type(), 0);
            }

            // Convert the pointer value to a string pointer using bitcast
            LLVMTypeRef stringPtrType = LLVM.PointerType(LLVM.Int8Type(), 0); // Assuming the pointer is to an i8*
            LLVMOpaqueValue* stringPtr = LLVM.BuildGlobalStringPtr(this.builder, (staticMappingForPrint[valueType]+newline).ToSBytePointer(), "stringParam".ToSBytePointer());

            LLVMOpaqueValue*[] values = { stringPtr, evaluatedExpression};

            // Call printf function
            // Create LLVM IR function prototype for printf
            LLVMOpaqueType*[] printfArgs = { stringPtrType, valueType };

            // call to puts function from c stdlib

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
            string functionName = context.MAIN()?.GetText() != null ? "main" : context.functionName().GetText();

            LLVMTypeRef returnType = LLVM.Int32Type(); // Assuming the return type is int for simplicity

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
            LLVM.BuildRet(builder, LLVM.ConstInt(LLVM.Int32Type(), 0, 0));
        }
    }
}
