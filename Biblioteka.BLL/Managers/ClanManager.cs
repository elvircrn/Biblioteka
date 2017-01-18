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

        // OK
        private List<IClan> Clans
        {
            get
            {
                if (clansCache == null)
                    clansCache = _context.Clans.Include("WishList").Include("Roles").ToList().Select(x => (IClan)x).ToList();
                return clansCache;
            }
            set { clansCache = value; }
        }

        // OK
        public ClanManager(ApplicationDbContext context)
        {
            _context = context;
        }

        // OK
        private string GenerateSifra()
        {
            string sifra;
            do
            {
                sifra = SifraGenerator.GenerateSifra(SifraLength);
            } while (_context.Clans.Where(x => x.Sifra == sifra).FirstOrDefault() != null);
            return sifra;
        }

        // OK
        public IClan AddClan(IClan clan)
        {
            var query = _context.Clans.Where(x => x.ClanId == clan.ClanId).FirstOrDefault();
            if (query == null)
            {
                clan.Sifra = GenerateSifra();
                Clans.Add(clan);
                _context.Clans.Add((Clan)clan);
                _context.SaveChanges();
                return clan;
            }
            else
                return clan;
        }

        // OK
        public bool RemoveClan(IClan clan)
        {
            var query = _context.Clans.Where(x => x == clan).FirstOrDefault();

            if (query == null)
                return false;

            _context.Clans.Remove(query);
            Clans.Remove(query);
            _context.SaveChanges();

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

        // OK
        public bool RemoveClanById(string clanId)
        {
            var query = _context.Clans.Where(x => x.Sifra == clanId).FirstOrDefault();
            if (query != null)
            {
                Clans.Remove(Clans.Where(x => x.Sifra == clanId).FirstOrDefault());
                _context.Clans.Remove(query);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
