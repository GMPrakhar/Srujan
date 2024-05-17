using LLVMSharp.Interop;
using Srujan.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
