using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class KnjigaManager
    {
        private static readonly int SifraLength = 10;

        private List<Knjiga> _knjige;

        public KnjigaManager()
        {
            _knjige = new List<Knjiga>();
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
            _knjige.Add(knjiga);
            return knjiga;
        }

        public Knjiga SearchByISBN(string isbn)
        {
            return _knjige.Where(x => x.ISBN == isbn).FirstOrDefault();
        }

        public delegate bool Comparator(Knjiga knjiga);

        public List<Knjiga> SearchByNaziv(string naziv, Comparator comparator = null)
        {
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
            return _knjige.Remove(knjiga);
        }

        internal void Print()
        {
            if (_knjige.Count == 0)
                Console.WriteLine("Nema knjiga.");
            else
            {
                Console.WriteLine("Spisak knjiga:");
                foreach (Knjiga knjiga in _knjige)
                    knjiga.Print();
                Console.WriteLine();
            }
        }
    }
}
