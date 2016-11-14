using Biblioteka.Users;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Model
{
    public sealed class ClanManager
    {
        public static readonly int SifraLength = 10;

        private List<IClan> Clans { get; set; }

        public ClanManager()
        {
            Clans = new List<IClan>();
        }

        private string GenerateSifra()
        {
            string sifra;
            do
            {
                sifra = SifraGenerator.GenerateSifra(SifraLength);
            } while (Clans.Find(x => x.Sifra == sifra) != null);
            return sifra;
        }

        public IClan AddClan(IClan clan)
        {
            clan.Sifra = GenerateSifra();
            Clans.Add(clan);
            return clan;
        }

        public bool RemoveClan(IClan clan)
        {
            var query = Clans.Where(x => x == clan).FirstOrDefault();

            if (query == null)
                return false;

            Clans.Remove(query);

            return true;
        }
    }
}
