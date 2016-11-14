using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
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

            if (c == 13)
                Console.ReadLine();

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

        public static int GetNextNumber(bool force = false, int? minRange = null, int? maxRange = null)
        {
            int result = 0;
            if (!force)
            {
                if (!Int32.TryParse(GetUntilWhiteSpace(), out result))
                    throw new Exception("Invalidan input, ocekivan je broj!");
            }
            else
            {
                bool ok;
                do
                {
                    ok = true;
                    try
                    {
                        if (!Int32.TryParse(GetUntilWhiteSpace(), out result))
                            throw new Exception("Invalid input, ocekivan je broj");

                        if (minRange != null && maxRange != null && (minRange > result || result > maxRange))
                            throw new Exception("Invalid input, broj nije u trazenom opsegu");
                        else if (minRange != null && result < minRange)
                            throw new Exception("Invalid input, broj nije u trazenom opsegu");
                        else if (maxRange != null && result > maxRange)
                            throw new Exception("Invalid input, broj nije u trazenom opsegu");
                    }
                    catch (Exception e)
                    {
                        ok = false;
                        Console.WriteLine(e.Message);
                    }
                } while (!ok);
            }
            return result;
        }
    }
}
