using System.Collections.Generic;
using System.Linq;
using System;
using Biblioteka.Model;
using Biblioteka.BLL.Managers;
using Biblioteka.Common.Security;
using Biblioteka.BLL.Interfaces;
using Biblioteka.DAL;

namespace Biblioteka.BLL.Managers
{
    public sealed class ClanManager : IClanManager
    {
        public static readonly int SifraLength = 10;
        private ApplicationDbContext _context;
        private List<IClan> clansCache;

        private List<IClan> Clans
        {
            get
            {
                if (clansCache == null)
                    clansCache = _context.Clans.ToList().Select(x => (IClan)x).ToList();
                return clansCache;
            }
        }

        public ClanManager(ApplicationDbContext context)
        {
            context = _context;
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

        public List<IClan> GetClans(string keywords = "")
        {
            if (keywords != "")
                return Clans.Where(x => x.ToString().Contains(keywords)).ToList();
            else
                return Clans;
        }

        public bool RemoveClanById(string clanId)
        {
            return Clans.Remove(Clans.Where(x => x.Sifra == clanId).FirstOrDefault());
        }
    }
}
