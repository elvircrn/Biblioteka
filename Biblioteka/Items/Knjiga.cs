using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;

namespace Biblioteka.Model
{
    public class Knjiga
    {
        public int KnjigaId { get; set; }

        public string Naslov { get; set; }

        public ICollection<Author> SpisakAutora { get; set; }

        public string Sifra { get; set; }

        public string Zanr { get; set; }

        public int GodinaIzdanja { get; set; }

        public string ISBN { get; set; }

        public bool Taken { get; set; }

        public override string ToString()
        {
            string ret = "";
            ret += Naslov;
            foreach (var autor in SpisakAutora)
                ret += autor.Name;
            ret += Zanr;
            ret += ISBN;
            return ret;
        }
    }
}
