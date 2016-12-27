using Biblioteka.BLL;
using Biblioteka.BLL.Interfaces;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.BLL
{
    public class KnjigaManager : IKnjigaManager
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

        public static KnjigaManager Seed()
        {
            KnjigaManager knjigaManager = new KnjigaManager();

            for (int i = 1; i <= 9; i++)
            {
                knjigaManager.AddKnjiga(new Knjiga
                {
                    Naslov = "Naslov1",
                    GodinaIzdanja = 1233,
                    ISBN = "ISBN-13 978-3-642-11746-" + i.ToString(),
                    SpisakAutora = (new List<string>(3)).Select(x => "Autor " + i.ToString()).ToList(),
                    Taken = false,
                    Zanr = "Zanr" + i.ToString()
                });
            }
            for (int i = 1; i <= 9; i++)
            {
                knjigaManager.AddKnjiga(new Knjiga
                {
                    Naslov = "Naslov1" + i.ToString(),
                    GodinaIzdanja = 1233,
                    ISBN = "ISBN-13 978-3-642-11746-" + i.ToString(),
                    SpisakAutora = (new List<string>(3)).Select(x => "Autor " + i.ToString()).ToList(),
                    Taken = false,
                    Zanr = "Zanr" + i.ToString()
                });
            }

            return knjigaManager;
        }

        public Knjiga GetById(string id)
        {
            return _knjige.Where(x => x.Sifra == id).FirstOrDefault();
        }

        public bool RemoveKnjiga(Knjiga knjiga)
        {
            return _knjige.Remove(knjiga);
        }

        public List<Knjiga> SearchByKeyword(string keyword)
        {
            return _knjige.Where(x => x.ToString().Contains(keyword)).ToList();
        }
    }
}
