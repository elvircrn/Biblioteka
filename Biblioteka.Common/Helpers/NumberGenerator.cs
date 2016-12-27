using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public static class NumberGenerator
    {
        private static Random _rand;

        public static int GetRandomNumber(int min, int max)
        {
            if (_rand == null)
                _rand = new Random();

            return _rand.Next(min, max);
        }
        public static int GetRandomNumber(int max)
        {
            if (_rand == null)
                _rand = new Random();

            return _rand.Next(max);
        }
    }
}
