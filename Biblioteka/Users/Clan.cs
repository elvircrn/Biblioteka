using Biblioteka;
using Biblioteka.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Clan : User, IClan
    {
        public virtual double Popust
        {
            get { return 0; }
        }

        public string Comment { get; set; }

        public string Sifra { get; set; }

        public States State { get; set; }

        public double Cash { get; set; }

        public List<Knjiga> WishList { get; set; }
    }
}
