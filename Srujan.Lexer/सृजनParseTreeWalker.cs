using Antlr4.Runtime.Tree;
using LLVMSharp.Interop;
using Srujan.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srujan
{
    internal unsafe class सृजनParseTreeWalker : ParseTreeWalker
    {
        private LLVMBuilderRef builder;
        private CompilerListener listener;

        public सृजनParseTreeWalker(LLVMBuilderRef builder, CompilerListener listener)
        {
            this.builder = builder;
            this.listener = listener;
        }

        public override void Walk(IParseTreeListener listener, IParseTree t)
        {
            if (t is IErrorNode)
            {
                listener.VisitErrorNode((IErrorNode)t);
                return;
            }

            if (t is ITerminalNode)
            {
                listener.VisitTerminal((ITerminalNode)t);
                return;
            }

            if(t is सृजनParser.IfStatementContext)
            {
                if(listener is not CompilerListener)
                {
                    throw new InvalidOperationException("Listener must be of type CompilerListener");
                }

                new IfStatementWalker(builder, listener as CompilerListener, this).EnterIfStatement(t as सृजनParser.IfStatementContext);
                return;
            }

            if (t is सृजनParser.WhileLoopContext)
            {
                if (listener is not CompilerListener)
                {
                    throw new InvalidOperationException("Listener must be of type CompilerListener");
                }

                new WhileStatementWalker(builder, listener as CompilerListener, this).EnterWhileStatement(t as सृजनParser.WhileLoopContext);
                return;
            }

            IRuleNode ruleNode = (IRuleNode)t;
            EnterRule(listener, ruleNode);
            int childCount = ruleNode.ChildCount;
            for (int i = 0; i < childCount; i++)
            {
                Walk(listener, ruleNode.GetChild(i));
            }

            ExitRule(listener, ruleNode);
        }
    }
}
