using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public sealed class ClanManager
    {
        public static readonly int SifraLength = 10;

        public List<Clan> Clans { get; set; }

        private string GenerateSifra()
        {
            string sifra;
            do
            {
                sifra = SifraGenerator.GenerateSifra(SifraLength);
            } while (Clans.Find(x => x.Sifra == sifra) != null);
            return sifra;
        }

        Clan AddClan(Clan clan)
        {
            clan.Sifra = GenerateSifra();
            Clans.Add(clan);
            return clan;
        }
    }
}
