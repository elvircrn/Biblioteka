using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.BLL.Interfaces
{
    public interface IKnjigaManager
    {
        Knjiga AddKnjiga(Knjiga knjiga);
        Knjiga GetById(string id);
        bool RemoveKnjiga(Knjiga knjiga);
        Knjiga SearchByISBN(string isbn);
        List<Knjiga> SearchByNaziv(string naziv, KnjigaManager.Comparator comparator = null);
        List<Knjiga> SearchByKeyword(string keyword);
        List<Knjiga> GetKnjige();
    }
}