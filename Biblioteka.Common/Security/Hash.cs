using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Common.Security
{
    public static class Hash
    {
        private static MD5 md5;

        public static string Encode(string text)
        {
            if (md5 == null)
                md5 = MD5.Create();
            byte[] buffer = md5.ComputeHash(new UTF8Encoding().GetBytes(text));
            return System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }
    }
}
