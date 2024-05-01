using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srujan.Lexer
{
    internal static class StringEx
    {
        public static unsafe sbyte* ToSBytePointer(this string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            sbyte* sp;
            fixed (byte* p = bytes)
            {
                sp = (sbyte*)p;
            }

            return sp;
        }
    }
}
