using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class User
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string MaticniBroj { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public IRole Role { get; set; }

        public string WorkID { get; set; }
    }
}
