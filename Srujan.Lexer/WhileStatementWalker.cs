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
            LLVMOpaqueValue* condition = ConditionBuilder.GetFinalConditionForAllComparisions(this.listener, this.builder, context.condition());

            LLVM.BuildCondBr(builder, condition, loop, after);

            LLVM.PositionBuilderAtEnd(builder, loop);

            foreach(var statement in context.statement())
            {
                if(statement.breakStatement() != null)
                {
                    LLVM.BuildBr(builder, after);

                    LLVM.PositionBuilderAtEnd(builder, after);

                    // No need to walk further as we are breaking out of the loop
                    return;
                }

                if(statement.continueStatement() != null)
                {
                    break;
                }

                this.parentWalker.Walk(this.listener, statement);
            }

            LLVM.BuildBr(builder, beforeLoop);
            LLVM.PositionBuilderAtEnd(builder, after);

        }
    }
}
