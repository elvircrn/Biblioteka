using Biblioteka.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class User : IClan, ICloneable
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string MaticniBroj { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public double Popust { get; set; }

        public string Comment { get; set; }

        public string Sifra { get; set; }

        public virtual object Clone()
        {
            return new User
            {
                Ime = this.Ime,
                Prezime = this.Prezime,
                MaticniBroj = this.MaticniBroj,
                DatumRodjenja = this.DatumRodjenja,
                Popust = this.Popust,
                Comment = this.Comment,
                Sifra = this.Sifra
            };
        }
    }
}
