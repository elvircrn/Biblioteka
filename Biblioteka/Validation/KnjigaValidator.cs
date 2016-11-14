using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;
using System.Text.RegularExpressions;

namespace Biblioteka.Validation
{
    public static class KnjigaValidator
    {
        public static readonly string ISBNREG = @"ISBN\x20(?=.{13}$)\d{1,5}([- ])\d{1,7}\1\d{1,6}\1(\d|X)$";

        public static bool IsISBNValid(string isbn)
        {
            return Regex.IsMatch(isbn, ISBNREG);
        }

        public static bool IsValid(this Knjiga knjiga, out List<string> errorMessages)
        {
            bool result = true;
            errorMessages = new List<string>();

            if (!IsISBNValid(knjiga.ISBN))
            {
                errorMessages.Add("ISBN not valid!");
                result = false;
            }

            return result;
        }
    }
}
