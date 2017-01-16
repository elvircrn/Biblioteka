using Biblioteka.Model;
using System;
using System.Collections.Generic;

namespace Biblioteka.Model
{
    public enum States { OK, Banned }

    public interface IClan
    {
        States State { get; set; }

        double Popust { get; }

        string Comment { get; set; }

        string Sifra { get; set; }

        ICollection<Knjiga> WishList { get; set; }
    }
}
