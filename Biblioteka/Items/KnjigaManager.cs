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

        public Knjiga SearchByNaziv(string naziv)
        {
            return _knjige.Where(x => x.Naslov == naziv).FirstOrDefault();
        }
    }
}
