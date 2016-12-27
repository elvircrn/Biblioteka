using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Common.Validation
{
    public static class StudentValidator
    {
        public static bool IsIndexValid(string index)
        {
            return (index.Length == 5 && index.Where(x => !Char.IsDigit(x)).FirstOrDefault() == 0 && index[0] != '0');
        }
    }
}
