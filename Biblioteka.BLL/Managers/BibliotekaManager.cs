using Biblioteka.BLL;
using Biblioteka.BLL.Interfaces;
using Biblioteka.BLL.Managers;
using Biblioteka.DAL;
using Biblioteka.Items;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.BLL.Managers
{
    public class BibliotekaManager : IBibliotekaManager
    {
        #region Properties

        private ApplicationDbContext _context;

        private static readonly double MonthlyDefault = 100.0;

        private IClanManager _clanManager;
        private IKnjigaManager _knjigaManager;
        private List<LogItem> _log;

        //private List<Tuple<Knjiga, IClan, DateTime>> _recordCache;
        private List<Record> _recordCache;

        private List<Record> _record
        {
            get
            {
                if (_recordCache == null)
                    _recordCache = _context.Records.Include("Knjiga").Include("Clan").ToList();
                return _recordCache;
            }
        }
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

        private void Inject(IClanManager clanManager,
                          IKnjigaManager knjigaManager)
        {
            _clanManager = clanManager;
            _knjigaManager = knjigaManager;
        }

        public string Ime { get; set; }

        public BibliotekaManager(ApplicationDbContext context,
                                 string Ime, 
                                 IClanManager clanManager,
                                 IKnjigaManager knjigaManager, 
                                 double? price = null)
        {
            Inject(clanManager, knjigaManager);

            _context = context;

            this.Ime = Ime;

            if (price != null)
                MonthlyFee = (double)price;

            _log = new List<LogItem>();

            Cash = 0.0;
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
        public List<Tuple<int, string>> Analyze()
        {
            // Uradi se grupisanje po zanru, pa se onda oni soritraju po broju iznajmljivanja
            var res = _log.Where(x => x.LogAction == LogItem.Action.Posudio)
                                     .ToList()
                                     .GroupBy(x => x.Knjiga.Zanr)
                                     .Select(group => new
                                     {
                                         Metric = group.Key,
                                         Count = group.Count()
                                     })
                                     .OrderByDescending(x => x.Count)
                                     .ToList()
                                     .Select(x => new Tuple<int, string>(x.Count, x.Metric))
                                     .ToList();

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
            return res;
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

        // OK
        public bool RemoveKnjigaById(string id)
        {
            _record.RemoveAll(x => x.Item1.Sifra == id);
            _context.Records.RemoveRange(_context.Records.Where(x => x.Knjiga.Sifra == id).ToList());
            _context.SaveChanges();
            return _knjigaManager.RemoveKnjiga(GetKnjigaById(id));
        }

        // OK
        public bool VratiKnjigu(string clanId, string sifra)
        {
            var query = _context.Records.Where(x => x.Item2.Sifra == clanId && x.Item1.Sifra == sifra)
                                        .FirstOrDefault();

            if (query == null)
                return false;

            var queryCache = _recordCache.Where(x => x.Item2.Sifra == clanId && x.Item1.Sifra == sifra)
                                        .FirstOrDefault();

            query.Item1.Taken = false;
            if (queryCache != null)
                queryCache.Item1.Taken = false;

            _log.Add(new LogItem
            {
                DateTime = CurrentDate,
                Clan = query.Item2,
                Knjiga = query.Item1,
                LogAction = LogItem.Action.Vratio
            });

            _context.Records.Remove(query);

            if (queryCache != null)
                _recordCache.Remove(queryCache);

            _context.SaveChanges();
            return true;
        }

        // OK
        public void RazduziSve(IClan clan)
        {
            var knjige = _context.Records.Where(x => x.Item2.Sifra == clan.Sifra)
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
            _context.Records.RemoveRange(_context.Records.Where(x => x.Item2.Sifra == clan.Sifra).ToList());

            // Update the cache
            var knjigeChe = _recordCache.Where(x => x.Item2.Sifra == clan.Sifra)
                                     .ToList()
                                     .Select(x => x.Item1)
                                     .ToList();

            foreach (Knjiga knjiga in knjigeChe)
                knjiga.Taken = false;
            _record.RemoveAll(x => x.Item2.Sifra == clan.Sifra);
            _context.SaveChanges();
        }

        // OK
        void AddRecord(Tuple<Knjiga, IClan, DateTime> record)
        {
            _context.Records.Add(new Record
            {
                Knjiga = record.Item1,
                Clan = (Clan)record.Item2,
                RentDate = record.Item3
            });

            _recordCache.Add(new Record
            {
                Knjiga = record.Item1,
                Clan = (Clan)record.Item2,
                RentDate = record.Item3
            });
            _context.SaveChanges();
        }

        // OK
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
                AddRecord(new Tuple<Knjiga, IClan, DateTime>(knjiga, clan, deadline));
                _log.Add(new LogItem
                {
                    DateTime = CurrentDate,
                    Clan = clan,
                    Knjiga = knjiga,
                    LogAction = LogItem.Action.Posudio
                });
            }

            _context.SaveChanges();

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

        void IBibliotekaManager.Analyse()
        {
            throw new NotImplementedException();
        }
    }
}

