using Biblioteka.BLL;
using Biblioteka.BLL.Interfaces;
using Biblioteka.BLL.Managers;
using Biblioteka.Model;
using Biblioteka.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.BLL.Managers
{
    public class BibliotekaManager : IBibliotekaManager
    {
        #region Properties

        private static readonly double MonthlyDefault = 100.0;

        private IClanManager _clanManager;
        private IKnjigaManager _knjigaManager;
        private List<Tuple<Knjiga, IClan, DateTime>> _record;
        private List<LogItem> _log;

        public double MonthlyFee { get; set; } = MonthlyDefault;

        private DateTime CurrentDate
        {
            get
            {
                return DateTime.Now;
            }
        }


        private double Cash { get; set; }

        public List<Knjiga> Knjige { get; set; }

        #endregion



        // Dependency injection :P
        private void Inject(IClanManager clanManager,
                          IKnjigaManager knjigaManager)
        {
            _clanManager = clanManager;
            _knjigaManager = knjigaManager;
        }

        public string Ime { get; set; }

        public BibliotekaManager(string Ime, 
                                 IClanManager clanManager,
                                 IKnjigaManager knjigaManager, 
                                 double? price = null)
        {
            Inject(clanManager, knjigaManager);

            this.Ime = Ime;

            if (price != null)
                MonthlyFee = (double)price;

            _record = new List<Tuple<Knjiga, IClan, DateTime>>();
            _log = new List<LogItem>();

            Cash = 0.0;
        }

        public static IBibliotekaManager Seed(IClanManager clanManager, IKnjigaManager knjigaManager)
        {
            IBibliotekaManager bibliotekaManager = new BibliotekaManager("Dobrinja", clanManager, knjigaManager, 20);

            IClan clan = clanManager.GetClans()[0];

            int adv = 0;

            List<string> errorList = new List<string>();
            foreach (var knjiga in knjigaManager.SearchByNaziv("Naslov1"))
                bibliotekaManager.Iznajmi(clan.Sifra, knjiga.Sifra, DateTime.Now.AddDays(adv++), out errorList);

            return bibliotekaManager;
        }

        public Knjiga SearchByISBN(string isbn)
        {
            return _knjigaManager.SearchByISBN(isbn);
        }

        public List<Knjiga> SearchByNaziv(string naziv, bool strict = false)
        {
            if (strict)
                return _knjigaManager.SearchByNaziv(naziv, (Knjiga x) => x.Naslov.Contains(naziv));
            else
                return _knjigaManager.SearchByNaziv(naziv);
        }

        public IClan AddClan(IClan clan)
        {
            clan.State = States.OK;
            return _clanManager.AddClan(clan);
        }

        public bool RemoveClan(IClan clan)
        {
            return _clanManager.RemoveClan(clan);
        }


        /*
         * Obzirom na to da se sva desavanja u biblioteci logiraju,
         * broj mogucih kverija je jako velik i lahko se moze doci
         * do zeljenih informacija pomocu LINQa. */
        public void Analyse()
        {
            // Uradi se grupisanje po zanru, pa se onda oni soritraju po broju iznajmljivanja


            var list1 = _log.Where(x => x.LogAction == LogItem.Action.Posudio)
                                     .ToList()
                                     .GroupBy(x => x.Knjiga.Zanr)
                                     .Select(group => new
                                     {
                                         Metric = group.Key,
                                         Count = group.Count()
                                     })
                                     .OrderByDescending(x => x.Count);

            var list2 = _log.Where(x => x.LogAction == LogItem.Action.Posudio)
                                     .ToList()
                                     .GroupBy(x => x.Clan.Sifra)
                                     .Select(group => new
                                     {
                                         Metric = group.Key,
                                         Count = group.Count()
                                     })
                                     .OrderByDescending(x => x.Count);

            var list3 = _clanManager.GetClans()
                                     .GroupBy(x => ((Clan)x).DatumRodjenja.Year)
                                     .Select(group => new
                                     {
                                         Metric = group.Key,
                                         Count = group.Count()
                                     })
                                     .OrderByDescending(x => x.Count);
        }

        public bool AddKnjiga(Knjiga knjiga)
        {
            _knjigaManager.AddKnjiga(knjiga);
            return true;
        }

        public Knjiga GetKnjigaById(string id)
        {
            return _knjigaManager.GetById(id);
        }

        public bool RemoveKnjigaById(string id)
        {
            _record.RemoveAll(x => x.Item1.Sifra == id);
            return _knjigaManager.RemoveKnjiga(GetKnjigaById(id));
        }

        public bool VratiKnjigu(string clanId, string sifra)
        {
            var query = _record.Where(x => x.Item2.Sifra == clanId && x.Item1.Sifra == sifra)
                               .FirstOrDefault();

            if (query == null)
                return false;

            query.Item1.Taken = false;

            _log.Add(new LogItem
            {
                DateTime = CurrentDate,
                Clan = query.Item2,
                Knjiga = query.Item1,
                LogAction = LogItem.Action.Vratio
            });

            _record.Remove(query);

            return true;
        }

        public void RazduziSve(IClan clan)
        {
            var knjige = _record.Where(x => x.Item2.Sifra == clan.Sifra)
                                .ToList()
                                .Select(x => x.Item1)
                                .ToList();

            foreach (Knjiga knjiga in knjige)
            {
                knjiga.Taken = false;
                _log.Add(new LogItem
                {
                    DateTime = CurrentDate,
                    Clan = clan,
                    Knjiga = knjiga,
                    LogAction = LogItem.Action.Vratio
                });
            }

            _record.RemoveAll(x => x.Item2.Sifra == clan.Sifra);
        }

        public bool Iznajmi(string clanId, string knjigaId, DateTime deadline, out List<string> errorMessages)
        {
            bool ok = true;
            IClan clan = _clanManager.GetById(clanId);
            Knjiga knjiga = _knjigaManager.GetById(knjigaId);

            errorMessages = new List<string>();

            if (clan == null)
            {
                ok = false;
                errorMessages.Add("Taj clan ne postoji.");
            }

            if (knjiga == null)
            {
                ok = false;
                errorMessages.Add("Ta knjiga ne postoji.");
            }
            else if (knjiga.Taken)
            {
                ok = false;
                errorMessages.Add("Ta knjiga je zauzeta.");
            }

            if (clan?.State == States.Banned)
            {
                ok = false;
                errorMessages.Add("User je banovan!");
            }

            if (ok)
            {
                knjiga.Taken = true;
                _record.Add(new Tuple<Knjiga, IClan, DateTime>(knjiga, clan, deadline));
                _log.Add(new LogItem
                {
                    DateTime = CurrentDate,
                    Clan = clan,
                    Knjiga = knjiga,
                    LogAction = LogItem.Action.Posudio
                });
            }

            return ok;
        }

        public List<IClan> Naplati()
        {
            List<IClan> banList = _clanManager.Take(MonthlyFee);

            foreach (IClan clan in banList)
            {
                clan.State = States.Banned;
                RazduziSve(clan);
            }

            return banList;
        }

        public IClan SearchClanBySifra(string id)
        {
            return _clanManager.GetById(id);
        }

        public List<IClan> SearchBy(Func<IClan, bool> f)
        {
            return _clanManager.Search(f);
        }

        public bool RemoveClanById(string id)
        {
            IClan clan = SearchClanBySifra(id);

            return _clanManager.RemoveClan(clan);
        }

        public List<Tuple<Knjiga, DateTime>> GetZaduzenja(IClan clan)
        {
            return _record.Where(x => x.Item2.Sifra == clan.Sifra).Select(x => new Tuple<Knjiga, DateTime>(x.Item1, x.Item3)).ToList();
        }
    }
}

