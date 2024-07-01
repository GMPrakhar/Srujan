using LLVMSharp.Interop;
using Srujan.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srujan
{
    internal unsafe class BitwiseOperatorBuilder
    {
        internal static LLVMValueRef CreateBitwiseOperation(CompilerListener compilerListener, LLVMBuilderRef builder, सृजनParser.ExpressionContext bitwiseOperatorContext, string op)
        {
            var expressions = bitwiseOperatorContext.expression();
            var left = compilerListener.EvaluateExpression(expressions[0]);

            if(op == "~")
            {
                return LLVM.BuildNot(builder, left, "nottmp".ToSBytePointer());
            }

            var right = compilerListener.EvaluateExpression(expressions[1]);


            switch (op)
            {
                case "&":
                    return LLVM.BuildAnd(builder, left, right, "andtmp".ToSBytePointer());
                case "|":
                    return LLVM.BuildOr(builder, left, right, "ortmp".ToSBytePointer());
                case "^":
                    return LLVM.BuildXor(builder, left, right, "xortmp".ToSBytePointer());
                case "<<":
                    return LLVM.BuildShl(builder, left, right, "shltmp".ToSBytePointer());
                case ">>":
                    return LLVM.BuildLShr(builder, left, right, "lshrtmp".ToSBytePointer());
                default:
                    throw new Exception($"Unknown bitwise operator {op}");
            }
        }
    }
}
