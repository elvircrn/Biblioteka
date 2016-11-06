using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class Parser 
    {
        public static string GetUntilWhiteSpace()
        {
            string buffer = "";
            char c = 'a';

            while (Char.IsWhiteSpace(c = (char)Console.Read())) ;
            while (!Char.IsWhiteSpace(c))
            {
                buffer += c;
                c = (char)Console.Read();
            }

            return buffer;
        }

        public static string GetUntil(char what, bool clearBuffer = true)
        {
            string buffer = "";
            char c = clearBuffer ? 'a' : (char)0;

            if (clearBuffer)
                while (Char.IsWhiteSpace(c = (char)Console.Read())) ;

            while (c != what)
            {
                buffer += c;
                c = (char)Console.Read();
            }

            return buffer;
        }
        
        public static int GetNextNumber()
        {
            int result;
            if (!Int32.TryParse(GetUntilWhiteSpace(), out result))
                throw new Exception("Invalid input");
            return result;
        }
    }
}
