using Biblioteka.Users;
using System.Collections.Generic;
using System.Linq;
using System;
using Biblioteka.Model;
using Biblioteka.BLL.Managers;
using Biblioteka.Common.Security;
using Biblioteka.BLL.Interfaces;

namespace Biblioteka.BLL.Managers
{
    public sealed class ClanManager : IClanManager
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

        public static ClanManager Seed(IUserManager userManager, IRoleManager roleManager)
        {
            ClanManager clanManager = new ClanManager();
            for (int i = 0; i < 10; i++)
            {
                Clan clan = new Clan
                {
                    Ime = "ClanIme" + i.ToString(),
                    Prezime = "ClanPrezime" + i.ToString(),
                    DatumRodjenja = new DateTime(1996, 7, i + 1),
                    MaticniBroj = "123456789123" + i.ToString(),
                    UserName = "clan" + i.ToString(),
                    PasswordHash = Hash.Encode("aaa"),
                    Sifra = i.ToString(),
                    Roles = new List<IRole>() { roleManager.GetRoleByName("CLAN") },
                    WishList = new List<Knjiga>()
                };
                clanManager.AddClan(clan);
                userManager.AddUser((User)clan);
            }
            return clanManager;
        }
    }
}
