using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public static class SifraGenerator
    {
        private static Random _rand;
        private static readonly string _pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateSifra(int length = 10)
        {
            if (_rand == null)
                _rand = new Random();
            return (new String(' ', length)).Select(x => _pool[_rand.Next(_pool.Length)]).ToList().Aggregate("", (x, y) => x += y);
        }
    }
}
