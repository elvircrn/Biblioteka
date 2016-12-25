using Biblioteka.Users;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public List<IClan> Take(double monthlyFee)
        {
            List<IClan> delta = new List<IClan>();

            foreach (Clan user in Clans)
            {
                Console.WriteLine(user.Popust);
                if (user.Cash > 0 && user.Cash - (monthlyFee * (1 - user.Popust)) < 0)
                    delta.Add(user);

                user.Cash -= monthlyFee;
            }

            return delta;
        }

        public IClan GetById(string id)
        {
            return Clans.Where(x => x.Sifra == id).FirstOrDefault();
        }

        public List<IClan> Search(Func<IClan, bool> f)
        {
            return Clans.Where(x => f(x)).ToList();
        }


        public List<IClan> GetClans()
        {
            return Clans;
        }
    }
}
