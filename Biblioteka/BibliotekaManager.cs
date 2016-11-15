using Biblioteka.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Model
{
    public class BibliotekaManager
    {
        #region Properties

        private static readonly double MonthlyDefault = 100.0;

        private ClanManager _clanManager;
        private RoleManager<Role> _roleManager;
        private KnjigaManager _knjigaManager;
        private List<Tuple<Knjiga, IClan>> _record;
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

        private void InitBooks()
        {

        }

        private void InitRoles()
        {
            _roleManager.AddRole(new Role("BACHELOR"));
            _roleManager.AddRole(new Role("MASTER"));
            _roleManager.AddRole(new Role("PROFESOR"));
        }

        private void Init()
        {
            _clanManager = new ClanManager();
            _roleManager = new RoleManager<Role>();
            _knjigaManager = new KnjigaManager();
            _record = new List<Tuple<Knjiga, IClan>>();
            _log = new List<LogItem>();

            InitRoles();
            InitBooks();

            Cash = 0.0;
        }

        public string Ime { get; set; }

        public BibliotekaManager(string Ime, double? price = null)
        {
            this.Ime = Ime;
            if (price != null)
                MonthlyFee = (double)price;
            Init();
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
            return _clanManager.AddClan(clan);
        }

        public bool RemoveClan(IClan clan)
        {
            return _clanManager.RemoveClan(clan);
        }

        public void Analyse()
        {
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

        public void PrintKnjige()
        {
            _knjigaManager.Print();
        }

        public void PrintClanova()
        {
            _clanManager.Print();
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

        public bool Iznajmi(string clanId, string knjigaId, out List<string> errorMessages)
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
                _record.Add(new Tuple<Knjiga, IClan>(knjiga, clan));
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

            foreach (User clan in banList)
            {
                clan.State = States.Banned;
                RazduziSve(clan);
            }

            return banList;
        }
    }
}
