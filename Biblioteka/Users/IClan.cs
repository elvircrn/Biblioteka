using System;

namespace Biblioteka.Users
{
    public interface IClan : ICloneable
    {
        double Popust { get; }

        string Comment { get; set; }

        string Sifra { get; set; }
    }
}
