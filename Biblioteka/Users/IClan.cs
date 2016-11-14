using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Users
{
    public interface IClan 
    {
        double Popust { get; set; }

        string Comment { get; set; }

        string Sifra { get; set; }
        /*
        {
            return new Clan
            {
                Ime = this.Ime,
                Prezime = this.Prezime,
                MaticniBroj = this.MaticniBroj,
                DatumRodjenja = this.DatumRodjenja,
                Role = this.Role,
                WorkID = this.WorkID,
                Popust = this.Popust,
                Comment = this.Comment,
                Sifra = this.Sifra
            };
        }
        */
    }
}
