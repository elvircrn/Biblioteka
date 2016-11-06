using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Knjiga
    {
        public string Naslov { get; set; }

        public List<string> SpisakAutora { get; set; }

        public string Sifra { get; set; }

        public string Zanr { get; set; }

        public int GodinaIzdanja { get; set; }
    }
}
