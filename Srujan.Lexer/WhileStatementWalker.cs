using Antlr4.Runtime.Tree;
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
    internal unsafe class WhileStatementWalker
    {
        private unsafe LLVMOpaqueBuilder* builder;
        private readonly CompilerListener listener;
        private ParseTreeWalker parentWalker;

        public WhileStatementWalker(LLVMOpaqueBuilder* builder, CompilerListener listener, सृजनParseTreeWalker parentWalker)
        {
            this.builder = builder;
            this.listener = listener;
            this.parentWalker = parentWalker;
        }

        public unsafe void EnterWhileStatement([NotNull] WhileLoopContext context)
        {
            var block = LLVM.GetInsertBlock(builder);
            var function = LLVM.GetBasicBlockParent(block);
            var beforeLoop = LLVM.AppendBasicBlock(function, "beforeLoop".ToSBytePointer());

            var loop = LLVM.AppendBasicBlock(function, "loop".ToSBytePointer());
            var after = LLVM.AppendBasicBlock(function, "afterLoop".ToSBytePointer());

            LLVM.BuildBr(builder, beforeLoop);

            LLVM.PositionBuilderAtEnd(builder, beforeLoop);
            var conditionExpressions = context.condition().expression();
            var leftExpression = this.listener.EvaluateExpression(conditionExpressions[0]);
            var rightExpression = this.listener.EvaluateExpression(conditionExpressions[1]);
            var operation = context.condition().comparisionOperator().GetText();
            LLVMOpaqueValue* condition = null;

            if (leftExpression.TypeOf == LLVM.DoubleType() || rightExpression.TypeOf == LLVM.DoubleType() || leftExpression.Kind == LLVMValueKind.LLVMInstructionValueKind)
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

            LLVM.BuildCondBr(builder, condition, loop, after);

            LLVM.PositionBuilderAtEnd(builder, loop);

            foreach(var statement in context.statement())
            {
                this.parentWalker.Walk(this.listener, statement);
            }

            LLVM.BuildBr(builder, beforeLoop);
            LLVM.PositionBuilderAtEnd(builder, after);

        }
    }
}
