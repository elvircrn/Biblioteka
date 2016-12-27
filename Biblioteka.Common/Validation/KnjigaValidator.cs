using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;
using System.Text.RegularExpressions;

namespace Biblioteka.Common.Validation
{
    public static class KnjigaValidator
    {
        /*
           Validno:
               ISBN-13 978-3-642-11746-6 | ISBN 978-3-642-11746-6 | ISBN-10 3-642-11746-5 SomeText | ISBN 3-642-11746-5 | ISBN: 978-3-642-11746-6
           Nije validno:
               ISBN : 978-3-642-11746-6 | ISBN-10 : 3-642-11746-5 | ISBN-13 : 978-3-642-11746-6
        */
        public static readonly string ISBNREG = @"ISBN(-1(?:(0)|3))?:?\x20(\s)*[0-9]+[- ][0-9]+[- ][0-9]+[- ][0-9]*[- ]*[xX0-9]";

        public static bool IsISBNValid(string isbn)
        {
            return Regex.IsMatch(isbn, ISBNREG) && TryValidate(isbn);
        }

        public static bool TryValidate(string isbn)
        {
            int index = 4;
            for (int i = isbn.Length - 1; i > -1; i--)
            {
                if (isbn[i] == ' ')
                {
                    index = i + 1;
                    break;
                }
            }
            isbn = isbn.Substring(index).Replace("-", "");
            return IsValidISBN10(isbn) || IsValidISBN13(isbn);
        }

        private static bool IsValidISBN10(string isbn10)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(isbn10))
            {
                if (isbn10.Contains("-")) isbn10 = isbn10.Replace("-", "");

                long j;

                if (isbn10.Length != 10 || !long.TryParse(isbn10.Substring(0, isbn10.Length - 1), out j))
                    return false;

                char lastChar = isbn10[isbn10.Length - 1];

                int sum = 0;
                for (int i = 0; i < 9; i++)
                    sum += int.Parse(isbn10[i].ToString()) * (i + 1);

                int remainder = sum % 11;

                if (lastChar == 'X')
                    result = (remainder == 10);
                else if (int.TryParse(lastChar.ToString(), out sum))
                    result = (remainder == int.Parse(lastChar.ToString()));
            }

            return result;
        }


        private static bool IsValidISBN13(string isbn13)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(isbn13))
            {
                if (isbn13.Contains("-")) isbn13 = isbn13.Replace("-", "");

                long temp;

                if (isbn13.Length != 13 || !long.TryParse(isbn13, out temp))
                    return false;

                int sum = 0;
                for (int i = 0; i < 12; i++)
                    sum += int.Parse(isbn13[i].ToString()) * (i % 2 == 1 ? 3 : 1);

                int remainder = sum % 10;
                int checkDigit = 10 - remainder;
                if (checkDigit == 10) checkDigit = 0;

                result = (checkDigit == int.Parse(isbn13[12].ToString()));
            }

            return result;
        }

        public static bool IsValid(this Knjiga knjiga, out List<string> errorMessages)
        {
            bool result = true;
            errorMessages = new List<string>();

            if (!IsISBNValid(knjiga.ISBN))
            {
                errorMessages.Add("ISBN nije validan!");
                result = false;
            }

            return result;
        }
    }
}
