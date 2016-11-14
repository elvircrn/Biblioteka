using Biblioteka.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class BibliotekaManager
    {
        #region Properties

        private static readonly double BachelorPopust = 10.0;
        private static readonly double MasterPopust = 12.5;
        private static readonly double ProfesorPopust = 15.0;
        private static readonly double MonthlyDefault = 100.0;

        private ClanManager _clanManager;
        private RoleManager<Role> _roleManager;
        private KnjigaManager _knjigaManager;
        private List<Tuple<Knjiga, IClan>> _record;
        private List<LogItem> _log;

        private DateTime CurrentDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        private double Monthly { get; set; }

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

            InitRoles();
            InitBooks();

            Cash = 0.0;
        }

        public string Ime { get; set; }

        public BibliotekaManager(string Ime)
        {
            this.Ime = Ime;
            Init();
        }

        public Knjiga SearchByISBN(string isbn)
        {
            return _knjigaManager.SearchByISBN(isbn);
        }

        public List<Knjiga> SearchByNaziv(string naziv)
        {
            return _knjigaManager.SearchByNaziv(naziv);
        }

        public bool TryIznajmi(Knjiga knjiga, IClan clan)
        {
            if (_record.Where(x => x.Item1 == knjiga).FirstOrDefault() != null)
                return false;

            _log.Add(new LogItem
            {
                DateTime = CurrentDate,
                Clan = (IClan)clan.Clone(),
                Knjiga = knjiga,
                LogAction = LogItem.Action.Posudio
            });

            _record.Add(new Tuple<Knjiga, IClan>(knjiga, clan));

            return true;
        }

        public bool Vrati(Knjiga knjiga, IClan clan)
        {
            var query = _record.Where(x => x.Item1 == knjiga).FirstOrDefault();

            if (query == null)
                return false;

            _log.Add(new LogItem
            {
                DateTime = CurrentDate,
                Clan = (IClan)clan.Clone(),
                Knjiga = knjiga,
                LogAction = LogItem.Action.Vratio
            });

            _record.Remove(query);

            return true;
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
            throw new NotImplementedException("Pitaj asistenta");
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
            return _knjigaManager.RemoveKnjiga(GetKnjigaById(id));
        }
    }
}
