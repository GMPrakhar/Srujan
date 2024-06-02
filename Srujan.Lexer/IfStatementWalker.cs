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
    internal unsafe class IfStatementWalker
    {
        private unsafe LLVMOpaqueBuilder* builder;
        private readonly CompilerListener listener;
        private ParseTreeWalker parentWalker;

        public IfStatementWalker(LLVMOpaqueBuilder* builder, CompilerListener listener, सृजनParseTreeWalker parentWalker)
        {
            this.builder = builder;
            this.listener = listener;
            this.parentWalker = parentWalker;
        }

        public unsafe void EnterIfStatement([NotNull] IfStatementContext context)
        {
            var function = LLVM.GetBasicBlockParent(LLVM.GetInsertBlock(builder));
            var conditionExpressions = context.condition().expression();
            var leftExpression = this.listener.EvaluateExpression(conditionExpressions[0]);
            var rightExpression = this.listener.EvaluateExpression(conditionExpressions[1]);
            var operation = context.condition().comparisionOperator().GetText();
            LLVMOpaqueValue* condition = ConditionBuilder.BuildConditionFromExpression(builder, leftExpression, rightExpression, operation);

            var thenBlock = LLVM.AppendBasicBlock(function, "then".ToSBytePointer());
            var elseBlock = LLVM.AppendBasicBlock(function, "else".ToSBytePointer());
            var mergeBlock = LLVM.AppendBasicBlock(function, "ifcont".ToSBytePointer());

            LLVM.BuildCondBr(builder, condition, thenBlock, elseBlock);

            LLVM.PositionBuilderAtEnd(builder, thenBlock);

            bool breakStatementFound = false;
            bool continueStatementFound = false;
            // Generate code for then block
            foreach (var statement in context.statement())
            {
                if(statement.breakStatement() != null)
                {
                    var loop = this.GetPreviousLoopBlock(LLVM.GetInsertBlock(builder));
                    LLVM.BuildBr(builder, loop);
                    breakStatementFound = true;
                    break;
                }
                if (statement.continueStatement() != null)
                {
                    var loop = this.GetPreviousLoopBlock(LLVM.GetInsertBlock(builder), true);
                    LLVM.BuildBr(builder, loop);
                    continueStatementFound = true;
                    break;
                }

                this.parentWalker.Walk(this.listener, statement);
            }

            if (!breakStatementFound && !continueStatementFound)
            {
                LLVM.BuildBr(builder, mergeBlock);
            }

            LLVM.PositionBuilderAtEnd(builder, elseBlock);

            if (context.elseStatement() != null)
            {
                // Generate code for else block
                foreach (var statement in context.elseStatement().statement())
                {
                    this.parentWalker.Walk(this.listener, statement);
                }
            }

            LLVM.BuildBr(builder, mergeBlock);

            LLVM.PositionBuilderAtEnd(builder, mergeBlock);
        }

        private LLVMBasicBlockRef GetPreviousLoopBlock(LLVMBasicBlockRef currentBlock, bool forContinueBlock = false)
        {
            var loopToFind = forContinueBlock ? "beforeLoop" : "afterLoop";

            // loop through parent blocks to find the loop block
            LLVMOpaqueBasicBlock* parentBlock = LLVM.GetPreviousBasicBlock(currentBlock);
            while (parentBlock != null)
            {
                var blockname = LLVM.GetBasicBlockName(parentBlock);
                // convert sbyte* to string
                var blockNameString = new string((sbyte*)blockname);
                if (blockNameString.Contains(loopToFind))
                {
                    return parentBlock;
                }

                parentBlock = LLVM.GetPreviousBasicBlock(parentBlock);
            }

            throw new InvalidOperationException("break statement must be used inside a loop.");
        }
    }
}
