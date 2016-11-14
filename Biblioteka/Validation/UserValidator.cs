using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Validation
{
    public static class UserValidator
    {
        public static bool ValidateMaticni(string maticni)
        {
            if (String.IsNullOrEmpty(maticni) || maticni.Length != 13 || maticni.Any(x => !Char.IsDigit(x)))
                return false;
            return true;
            /*
            int zbir = 0;

            int mult = 7;
            for (int i = 0; i < 6; i++)
                zbir += (mult--) * (maticni[i] - 0x30) + (maticni[i + 6] - 0x30);

            int ostatak = zbir % 11;
            int razlika = 11 - ostatak;

            if (ostatak == 1)
                return false;
            else if (ostatak == 0)
                return (maticni[12] == 0x30);

            return (razlika == (maticni[12] - 0x30));
            */
        }


        public static bool ValidateUser(this User user, out List<string> errorMessages)
        {
            bool result = true;
            errorMessages = new List<string>();

            if (!ValidateMaticni(user.MaticniBroj))
            {
                errorMessages.Add("Maticni broj nije validan.");
                result = false;
            }

            return result;
        }
    }
}
