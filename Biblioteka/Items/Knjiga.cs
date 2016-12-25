using Biblioteka.Validation;
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
        public string Naslov { get; set; }

        public List<string> SpisakAutora { get; set; }

        public string Sifra { get; set; }

        public string Zanr { get; set; }

        public int GodinaIzdanja { get; set; }

        public string ISBN { get; set; }

        public bool Taken { get; set; }

        public Knjiga()
        {
            SpisakAutora = new List<string>();
            Taken = false;
        }

    }
}
