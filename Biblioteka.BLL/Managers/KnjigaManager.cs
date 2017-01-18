using Biblioteka.BLL;
using Biblioteka.BLL.Interfaces;
using System.Threading.Tasks;
using Biblioteka.DAL;
using Biblioteka.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.BLL
{
    public class KnjigaManager : IKnjigaManager
    {
        ApplicationDbContext _context;
        private static readonly int SifraLength = 10;

        private List<Knjiga> _knjigasCache;

        private List<Knjiga> _knjige
        {
            get
            {
                if (_knjigasCache == null)
                    return _knjigasCache = _context.Knjigas.ToList();
                else
                    return _knjigasCache;
            }
        }

        public KnjigaManager(ApplicationDbContext context)
        {
            _context = context;
        }

        private string GenerateSifra()
        {
            string sifra;
            do
            {
                sifra = SifraGenerator.GenerateSifra(SifraLength);
            } while (_knjige.Find(x => x.Sifra == sifra) != null);
            return sifra;
        }

        public Knjiga AddKnjiga(Knjiga knjiga)
        {
            knjiga.Sifra = GenerateSifra();
            _context.Knjigas.Add(knjiga);
            _knjigasCache.Add(knjiga);
            _context.SaveChangesAsync();
            return knjiga;
        }

        public Knjiga SearchByISBN(string isbn)
        {
            return _knjige.Where(x => x.ISBN == isbn).FirstOrDefault();
        }

        public delegate bool Comparator(Knjiga knjiga);

        public List<Knjiga> SearchByNaziv(string naziv, Comparator comparator = null)
        {
            int ind = 0;
            var cd = new ConcurrentDictionary<int, Knjiga>(_knjige
                .Select(x => new KeyValuePair<int, Knjiga>(ind++, x))
                .ToList());

            if (comparator != null)
                return _knjige.Where(x => comparator(x)).ToList();
            else
                return _knjige.Where(x => x.Naslov == naziv).ToList();
        }

        public Knjiga GetById(string id)
        {
            return _knjige.Where(x => x.Sifra == id).FirstOrDefault();
        }

        public bool RemoveKnjiga(Knjiga knjiga)
        {
            _context.Knjigas.Remove(knjiga);
            return _knjige.Remove(knjiga);
        }

        public List<Knjiga> SearchByKeyword(string keyword)
        {
            return _knjige.Where(x => x.ToString().Contains(keyword)).ToList();
        }

        public List<Knjiga> GetKnjige()
        {
            return _knjige;
        }
    }
}
