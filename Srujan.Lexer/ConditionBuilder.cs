using LLVMSharp.Interop;
using Srujan.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static सृजनParser;

namespace Srujan
{
    internal unsafe static class ConditionBuilder
    {
        /// <summary>
        /// Builds condition from given expressions and operation.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="leftExpression"></param>
        /// <param name="rightExpression"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static LLVMOpaqueValue* BuildConditionFromExpression(LLVMBuilderRef builder, LLVMValueRef leftExpression, LLVMValueRef rightExpression, string operation)
        {
            LLVMOpaqueValue* condition;
            if (leftExpression.TypeOf == LLVM.DoubleType() || rightExpression.TypeOf == LLVM.DoubleType())
            {
                if (leftExpression.TypeOf == LLVM.Int32Type())
                {
                    leftExpression = LLVM.BuildSIToFP(builder, leftExpression, LLVM.DoubleType(), "casttmp".ToSBytePointer());
                }

                if (rightExpression.TypeOf == LLVM.Int32Type())
                {
                    rightExpression = LLVM.BuildSIToFP(builder, rightExpression, LLVM.DoubleType(), "casttmp".ToSBytePointer());
                }

                var predicate = operation switch
                {
                    "<" => LLVMRealPredicate.LLVMRealOLT,
                    ">" => LLVMRealPredicate.LLVMRealOGT,
                    "==" => LLVMRealPredicate.LLVMRealOEQ,
                    "<=" => LLVMRealPredicate.LLVMRealOLE,
                    ">=" => LLVMRealPredicate.LLVMRealOGE,
                    "!=" => LLVMRealPredicate.LLVMRealONE,
                    _ => throw new InvalidOperationException($"The operation {operation} is not supported between {leftExpression} and {rightExpression}"),
                };

                condition = LLVM.BuildFCmp(builder, predicate, leftExpression, rightExpression, "ifcond".ToSBytePointer());
            }
            else if (leftExpression.TypeOf != rightExpression.TypeOf)
            {
                throw new InvalidOperationException($"The operation {operation} is not supported between {leftExpression} and {rightExpression}");
            }
            else
            {
                var predicate = operation switch
                {
                    "<" => LLVMIntPredicate.LLVMIntSLT,
                    ">" => LLVMIntPredicate.LLVMIntSGT,
                    "==" => LLVMIntPredicate.LLVMIntEQ,
                    "<=" => LLVMIntPredicate.LLVMIntSLE,
                    ">=" => LLVMIntPredicate.LLVMIntSGE,
                    "!=" => LLVMIntPredicate.LLVMIntNE,
                    _ => throw new InvalidOperationException($"The operation {operation} is not supported between {leftExpression} and {rightExpression}"),
                };

                condition = LLVM.BuildICmp(builder, predicate, leftExpression, rightExpression, "ifcond".ToSBytePointer());
            }

            return condition;
        }

        internal static LLVMOpaqueValue* BuildConditionFromLogicalOperator(LLVMOpaqueBuilder* builder, LLVMOpaqueValue* condition, LLVMOpaqueValue* rightCondition, string logicalOperator)
        {
            LLVMOpaqueValue* result;
            if (logicalOperator == "&&")
            {
                result = LLVM.BuildAnd(builder, condition, rightCondition, "andtmp".ToSBytePointer());
            }
            else if (logicalOperator == "||")
            {
                result = LLVM.BuildOr(builder, condition, rightCondition, "ortmp".ToSBytePointer());
            }
            else
            {
                throw new InvalidOperationException($"The logical operator {logicalOperator} is not supported");
            }

            return result;
        }

        internal static unsafe LLVMOpaqueValue* GetFinalConditionForAllComparisions(CompilerListener listener, LLVMOpaqueBuilder* builder, ConditionContext context)
        {
            var conditionExpressions = context.expression();
            var leftExpression = listener.EvaluateExpression(conditionExpressions[0]);
            var rightExpression = listener.EvaluateExpression(conditionExpressions[1]);
            var operation = context.comparisionOperator()[0].GetText();
            LLVMOpaqueValue* condition = ConditionBuilder.BuildConditionFromExpression(builder, leftExpression, rightExpression, operation);

            // if context has logical operator, combine the conditional expressions into a single condition, there can be a series of logical operators
            if (context.logicalOperator() != null)
            {
                for (int i = 0; i < context.logicalOperator().Length; i++)
                {
                    var logicalOperator = context.logicalOperator()[i].GetText();
                    var leftExpression1 = listener.EvaluateExpression(conditionExpressions[i * 2 + 2]);
                    var rightExpression1 = listener.EvaluateExpression(conditionExpressions[i * 2 + 3]);
                    var operation1 = context.comparisionOperator()[i + 1].GetText();
                    LLVMOpaqueValue* rightCondition = ConditionBuilder.BuildConditionFromExpression(builder, leftExpression1, rightExpression1, operation1);

                    condition = ConditionBuilder.BuildConditionFromLogicalOperator(builder, condition, rightCondition, logicalOperator);
                }
            }

            return condition;
        }

        internal static unsafe LLVMOpaqueValue* GetFinalConditionForAllComparisions(CompilerListener listener, LLVMOpaqueBuilder* builder, ExpressionContext context)
        {
            var conditionExpressions = context.expression();
            var leftExpression = listener.EvaluateExpression(conditionExpressions[0]);
            var rightExpression = listener.EvaluateExpression(conditionExpressions[1]);
            var operation = context.comparisionOperator()[0].GetText();
            LLVMOpaqueValue* condition = ConditionBuilder.BuildConditionFromExpression(builder, leftExpression, rightExpression, operation);

            // if context has logical operator, combine the conditional expressions into a single condition, there can be a series of logical operators
            if (context.logicalOperator() != null)
            {
                for (int i = 0; i < context.logicalOperator().Length; i++)
                {
                    var logicalOperator = context.logicalOperator()[i].GetText();
                    var leftExpression1 = listener.EvaluateExpression(conditionExpressions[i * 2 + 2]);
                    var rightExpression1 = listener.EvaluateExpression(conditionExpressions[i * 2 + 3]);
                    var operation1 = context.comparisionOperator()[i + 1].GetText();
                    LLVMOpaqueValue* rightCondition = ConditionBuilder.BuildConditionFromExpression(builder, leftExpression1, rightExpression1, operation1);

                    condition = ConditionBuilder.BuildConditionFromLogicalOperator(builder, condition, rightCondition, logicalOperator);
                }
            }

            return condition;
        }
    }
}
