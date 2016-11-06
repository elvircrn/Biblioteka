using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Clan : User
    {
        public double Popust { get; set; }

        public string Comment { get; set; }

        public string Sifra { get; set; }
    }
}
