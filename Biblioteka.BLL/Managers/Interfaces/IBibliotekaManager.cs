using System;
using System.Collections.Generic;
using Biblioteka.Users;
using Biblioteka.Model;

namespace Biblioteka.BLL.Interfaces
{
    public interface IBibliotekaManager
    {
        string Ime { get; set; }
        List<Knjiga> Knjige { get; set; }
        double MonthlyFee { get; set; }

        IClan AddClan(IClan clan);
        bool AddKnjiga(Knjiga knjiga);
        void Analyse();
        List<Tuple<int, string>> Analyze();
        Knjiga GetKnjigaById(string id);
        bool Iznajmi(string clanId, string knjigaId, DateTime dateTime, out List<string> errorMessages);
        List<IClan> Naplati();
        void RazduziSve(IClan clan);
        bool RemoveClan(IClan clan);
        bool RemoveClanById(string id);
        bool RemoveKnjigaById(string id);
        List<IClan> SearchBy(Func<IClan, bool> f);
        Knjiga SearchByISBN(string isbn);
        List<Knjiga> SearchByNaziv(string naziv, bool strict = false);
        IClan SearchClanBySifra(string id);
        bool VratiKnjigu(string clanId, string sifra);
        List<Tuple<Knjiga, DateTime>> GetZaduzenja(IClan clan);
    }
}