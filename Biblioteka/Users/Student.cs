using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Users
{
    public class Student : User
    {
        public string Index { get; set; }

        public override object Clone()
        {
            return new Student 
            {
                Ime = (string)this.Ime.Clone(),
                Prezime = (string)this.Prezime.Clone(),
                MaticniBroj = (string)this.MaticniBroj.Clone(),
                DatumRodjenja = this.DatumRodjenja,
                Role = this.Role,
                Popust = this.Popust,
                Comment = (string)this.Comment.Clone(),
                Sifra = (string)this.Sifra.Clone(),
                Index = this.Index
            };
        }
    }
}
