using System;

namespace Biblioteka.Users
{
    public enum States { OK, Banned }
    public interface IClan
    {
        States State { get; set; }

        double Popust { get; }

        string Comment { get; set; }

        string Sifra { get; set; }

        void Print();
    }
}
