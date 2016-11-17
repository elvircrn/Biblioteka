using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Biblioteka.Model;
using Biblioteka;
using Biblioteka.Validation;
using Biblioteka.Users;
using IO;

namespace Test
{
    class Program
    {
        private enum Menus { Naplati, PrintClanova, PrintKnjiga, RegDelClan, Main, Hello, Izlaz, KnjigaInput, RegDelKnjiga, ClanInput, IznajmiVrati, Analiza, Pretraga, RegKnjiga, DelKnjiga, RegClan, DelClan, IznKnjigu, VraKnjigu, PoISBN, PoNazivu, PoSifri, PoImenu };

        static Stack<Menus> History17455 { get; set; }

        private static Menus CurrentMenu17455 { get; set; }

        private static int Index17455 { get; set; }

        private static string Buffer17455 { get; set; }

        private static BibliotekaManager _bibliotekaManager17455;

        private static void Nazad(bool ClearCurrent = false)
        {
            if (ClearCurrent)
                History17455.Pop();

            if (History17455.Count == 0)
                throw new Exception("Can't go back");
            CurrentMenu17455 = History17455.Peek();
            History17455.Pop();
        }

        private static void Render()
        {
            Console.Clear();
            if (CurrentMenu17455 == Menus.Hello)
            {
                Console.Write("Dobro došli u " +
                              _bibliotekaManager17455.Ime +
                              " biblioteku!\n");
            }
            else if (CurrentMenu17455 == Menus.Main)
            {
                Console.Write("1. Registruj / Briši knjigu\n" +
                              "2. Registruj / Briši člana\n" +
                              "3. Iznajmi / Vrati knjigu\n" +
                              "4. Pretraga\n" +
                              "5. Analiza sadržaja\n" +
                              "6. Printanje svih clanova\n" +
                              "7. Printanje svih itema u biblioteci\n" +
                              "8. Naplati \n" +
                              "9. Izlaz\n");
            }
            else if (CurrentMenu17455 == Menus.RegDelKnjiga)
            {
                Console.Write("1. Registruj Knjigu\n" +
                              "2. Briši knjigu\n" +
                              "3. Nazad\n");
            }
            else if (CurrentMenu17455 == Menus.RegDelClan)
            {
                Console.Write("1. Registruj clana\n" +
                              "2. Briši clana\n" +
                              "3. Nazad\n");
            }
            else if (CurrentMenu17455 == Menus.IznajmiVrati)
            {
                Console.Write("1. Iznajmi knjigu\n" +
                              "2. Vrati knjigu\n" +
                              "3. Nazad\n");
            }
            else if (CurrentMenu17455 == Menus.IznKnjigu)
            {
                CollectInput();
            }
            else if (CurrentMenu17455 == Menus.VraKnjigu)
            {
                CollectInput();
            }
            else if (CurrentMenu17455 == Menus.RegKnjiga)
            {
                Console.WriteLine("Koji tip?");
                Console.WriteLine("1. Knjiga");
                Console.WriteLine("2. Naucni rad");
                Console.WriteLine("3. Strip");
                Console.WriteLine("4. Nazad");
            }
            else if (CurrentMenu17455 == Menus.Pretraga)
            {
                Console.Write("1. Trazi knjigu po ISBN\n" +
                              "2. Trazi knjigu po naizvu\n" +
                              "3. Trazi usera po sifri\n" +
                              "4. Trazi usera po imenu\n" +
                              "5. Nazad\n");
            }
            else if (CurrentMenu17455 == Menus.PoNazivu)
            {
                Console.Write("Unesite naziv (q za nazad): ");
            }
            else if (CurrentMenu17455 == Menus.PoISBN)
            {
                Console.Write("Unesite ISBN (q za nazad): ");
            }
        }

        private static void CollectInput()
        {
            if (CurrentMenu17455 == Menus.Main ||
                CurrentMenu17455 == Menus.RegDelKnjiga ||
                CurrentMenu17455 == Menus.RegDelClan ||
                CurrentMenu17455 == Menus.Pretraga ||
                CurrentMenu17455 == Menus.IznajmiVrati ||
                CurrentMenu17455 == Menus.RegKnjiga)
            {
                Index17455 = Parser.GetNextNumber(true);
            }
        }

        private static void ProcessInput()
        {
            if (CurrentMenu17455 == Menus.Izlaz)
                System.Environment.Exit(0);
            else if (CurrentMenu17455 == Menus.Main)
            {
                History17455.Push(CurrentMenu17455);
                if (Index17455 == 1)
                    CurrentMenu17455 = Menus.RegDelKnjiga;
                else if (Index17455 == 2)
                    CurrentMenu17455 = Menus.RegDelClan;
                else if (Index17455 == 3)
                    CurrentMenu17455 = Menus.IznajmiVrati;
                else if (Index17455 == 4)
                    CurrentMenu17455 = Menus.Pretraga;
                else if (Index17455 == 5)
                    CurrentMenu17455 = Menus.Analiza;
                else if (Index17455 == 6)
                    CurrentMenu17455 = Menus.PrintClanova;
                else if (Index17455 == 7)
                    CurrentMenu17455 = Menus.PrintKnjiga;
                else if (Index17455 == 8)
                    CurrentMenu17455 = Menus.Naplati;
                else if (Index17455 == 9)
                    CurrentMenu17455 = Menus.Izlaz;
            }
            else if (CurrentMenu17455 == Menus.RegDelKnjiga)
            {
                History17455.Push(CurrentMenu17455);
                if (Index17455 == 1)
                    CurrentMenu17455 = Menus.RegKnjiga;
                else if (Index17455 == 2)
                    CurrentMenu17455 = Menus.DelKnjiga;
                else if (Index17455 == 3)
                    Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.RegKnjiga)
            {
                if (Index17455 == 1)
                {
                    History17455.Push(CurrentMenu17455);
                    Knjiga knjiga = new Knjiga();
                    knjiga.GetValid();
                    _bibliotekaManager17455.AddKnjiga(knjiga);
                    Nazad(true);
                }
                else if (Index17455 == 2)
                {
                    History17455.Push(CurrentMenu17455);
                    NaucniRad naucniRad = new NaucniRad();
                    naucniRad.GetValid();
                    _bibliotekaManager17455.AddKnjiga(naucniRad);
                    Nazad(true);
                }
                else if (Index17455 == 3)
                {
                    History17455.Push(CurrentMenu17455);
                    Strip strip = new Strip();
                    strip.GetValid();
                    _bibliotekaManager17455.AddKnjiga(strip);
                    Nazad(true);
                }
                else if (Index17455 == 4)
                {
                    Nazad(true);
                }
            }
            else if (CurrentMenu17455 == Menus.DelKnjiga)
            {
                History17455.Push(CurrentMenu17455);
                Console.Write("Unesite sifru knjige koju zelite izbrisati (q za nazad): ");

                string code = Console.ReadLine();
                if (code != "q")
                {
                    while (!_bibliotekaManager17455.RemoveKnjigaById(code))
                    {
                        Console.WriteLine("Knjiga sa tom sifrom ne postoji, unesite ponovo: ");
                        code = Console.ReadLine();
                        if (code == "q")
                            break;
                    }
                }

                Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.RegDelClan)
            {
                History17455.Push(CurrentMenu17455);
                if (Index17455 == 1)
                    CurrentMenu17455 = Menus.RegClan;
                else if (Index17455 == 2)
                    CurrentMenu17455 = Menus.DelClan;
                else if (Index17455 == 3)
                    Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.DelClan)
            {
                History17455.Push(CurrentMenu17455);
                Console.Write("Unesite sifru clana kojeg zelite izbrisati (q za nazad): ");

                string id = Console.ReadLine();
                if (id != "q")
                {
                    while (!_bibliotekaManager17455.RemoveClanById(id))
                    {
                        Console.WriteLine("Clan sa tom sifrom ne postoji, unesite ponovo (q za nazad): ");
                        id = Console.ReadLine();
                        if (id == "q")
                            break;
                    }
                }

                Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.IznajmiVrati)
            {
                History17455.Push(CurrentMenu17455);
                if (Index17455 == 1)
                    CurrentMenu17455 = Menus.IznKnjigu;
                else if (Index17455 == 2)
                    CurrentMenu17455 = Menus.VraKnjigu;
                else if (Index17455 == 3)
                    Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.Pretraga)
            {
                History17455.Push(CurrentMenu17455);
                if (Index17455 == 1)
                    CurrentMenu17455 = Menus.PoISBN;
                else if (Index17455 == 2)
                    CurrentMenu17455 = Menus.PoNazivu;
                else if (Index17455 == 3)
                    CurrentMenu17455 = Menus.PoSifri;
                else if (Index17455 == 4)
                    CurrentMenu17455 = Menus.PoImenu;
                else if (Index17455 == 5)
                    Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.PrintKnjiga)
            {
                History17455.Push(CurrentMenu17455);
                _bibliotekaManager17455.PrintKnjige();
                Parser.Stall(true);
                Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.PrintClanova)
            {
                History17455.Push(CurrentMenu17455);
                _bibliotekaManager17455.PrintClanova();
                Parser.Stall(true);
                Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.IznKnjigu)
            {
                History17455.Push(CurrentMenu17455);
                Console.Write("Unesi sifru knjige: ");
                string knjigaId = Console.ReadLine();
                Console.Write("Unesi sifru clana: ");
                string clanId = Console.ReadLine();

                List<string> errorMessages = null;
                if (!_bibliotekaManager17455.Iznajmi(clanId, knjigaId, out errorMessages))
                {
                    Console.WriteLine("Nije moguce iznajmniti zato sto:");
                    foreach (string error in errorMessages)
                        Console.WriteLine(error);
                    Parser.Stall();
                }

                Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.VraKnjigu)
            {
                History17455.Push(CurrentMenu17455);

                Console.Write("Unesi sifru clana: ");
                string clanId = Console.ReadLine();
                Console.Write("Unesi sifru knjige: ");
                string knjigaId = Console.ReadLine();

                if (!_bibliotekaManager17455.VratiKnjigu(clanId, knjigaId))
                {
                    Console.WriteLine("Nije moguce vratiti knjigu.");
                    Parser.Stall();
                }

                Nazad(true);

            }
            else if (CurrentMenu17455 == Menus.PoISBN)
            {
                History17455.Push(CurrentMenu17455);
                string isbn;

                while (!KnjigaValidator.IsISBNValid(isbn = Console.ReadLine()))
                {
                    if (isbn == "q")
                        break;
                    else
                        Console.Write("Unesite validan ISBN (q za nazad): ");
                }

                if (isbn != "q")
                {
                    Knjiga knjiga = _bibliotekaManager17455.SearchByISBN(isbn);

                    if (knjiga == null)
                        Console.WriteLine("Ne postoji knjiga sa tim ISBNom.");
                    else
                    {
                        Console.WriteLine("Rezultat pretrage:");
                        knjiga.Print();
                    }
                }

                Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.PoSifri)
            {
                History17455.Push(CurrentMenu17455);
                Console.Write("Unesite sifru: ");
                string sifra = Console.ReadLine();
                IClan result = _bibliotekaManager17455.SearchClanBySifra(sifra);

                if (result == null)
                    Console.WriteLine("Nije pronadjen clan sa tom sifrom.");
                else
                    result.Print();
                Parser.Stall();

                Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.PoImenu)
            {
                History17455.Push(CurrentMenu17455);
                Console.Write("Unesite ime clana: ");
                string ime = Console.ReadLine();
                List<IClan> result = _bibliotekaManager17455.SearchBy(x => ((User)x).Ime == ime);
                
                if (result.Count == 0)
                    Console.WriteLine("Nije pronadjen clan sa tim imenom.");
                else
                    foreach (IClan clan in result)
                        clan.Print();

                Parser.Stall();
                Nazad(true);
                
            }
            else if (CurrentMenu17455 == Menus.PoNazivu)
            {
                History17455.Push(CurrentMenu17455);
                string naziv = Console.ReadLine();

                if (naziv != "q")
                {
                    List<Knjiga> knjige = _bibliotekaManager17455.SearchByNaziv(naziv);

                    if (knjige == null)
                        Console.WriteLine("Ne postoji knjiga sa tim nazivom.");
                    else
                    {
                        Console.WriteLine("Rezultat pretrage:");
                        foreach (Knjiga knjiga in knjige)
                        {
                            knjiga.Print();
                            Console.WriteLine();
                        }
                    }
                }

                Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.Analiza)
            {
                History17455.Push(CurrentMenu17455);

                _bibliotekaManager17455.Analyse();

                Parser.Stall();
                Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.RegClan)
            {
                Console.WriteLine("Odaberite tip clana:");
                Console.WriteLine("1. Obicni insan");
                Console.WriteLine("2. Student (podaci o nivou studija studenta ce biti uneseni kasnije)");
                Console.WriteLine("3. Profesor");
                Console.WriteLine("4. Nazad");

                int index = Parser.GetNextNumber(true, 1, 4);

                if (index == 1)
                {
                    User user = new User();
                    user.PromptInput();
                    _bibliotekaManager17455.AddClan(user);
                    Nazad(true);
                }
                else if (index == 2)
                {
                    Student student = new Student();
                    student.PromptInput();
                    _bibliotekaManager17455.AddClan(student);
                    Nazad(true);
                }
                else if (index == 3)
                {
                    Profesor profesor = new Profesor();
                    profesor.PromptInput();
                    _bibliotekaManager17455.AddClan(profesor);
                    Nazad(true);
                }
                else if (index == 4)
                {
                    Nazad(true);
                }
            }
            else if (CurrentMenu17455 == Menus.KnjigaInput)
            {
                Knjiga knjiga = new Knjiga();
                knjiga.GetValid();

                _bibliotekaManager17455.AddKnjiga(knjiga);
                Nazad(true);
            }
            else if (CurrentMenu17455 == Menus.Naplati)
            {
                History17455.Push(CurrentMenu17455);
                var bannedList = _bibliotekaManager17455.Naplati();

                if (bannedList?.Count > 0)
                {
                    Console.WriteLine("Sljedeci useri vise ne mogu korisiti usluge biblioteke:");
                    foreach (var user in bannedList)
                    {
                        user.Print();
                        Console.WriteLine();
                    }
                    Parser.Stall();
                }

                Nazad(true);
            }

            Console.Clear();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Imam jednu molbu:\n" +
                              "Prije pokretanja ove aplikacije bi bilo " +
                              "jako pozeljno procitati " +
                              "README file koji se nalazi na root-u.\n" +
                              "Pritisnite enter da biste poceli koristiti ovu aplikaciju.");

            Console.ReadLine();
            Console.Clear();

            Init();

            Render();
            CurrentMenu17455 = Menus.Main;

            while (true)
            {
                Render();
                CollectInput();
                ProcessInput();
            }
        }

        private static void Init()
        {
            _bibliotekaManager17455 = new BibliotekaManager("Crnjo");
            History17455 = new Stack<Menus>();
            CurrentMenu17455 = Menus.Hello;

            Console.WriteLine("Dobrodosli u biblioteku " + _bibliotekaManager17455.Ime);
            Console.ReadLine();
            Console.Clear();

            Console.Write("Da li zelite da seedam biblioteku sa nekim pocetnim podacima? (Y/N): ");
            string buffer = Console.ReadLine();
            while (buffer != "Y" && buffer != "N")
            {
                Console.Write("Unos nije validan, pokusajte ponovo: ");
                buffer = Console.ReadLine();
            }

            if (buffer == "Y")
                Seed();
        }

        private static void Seed()
        {
            for (int i = 1; i <= 9; i++)
            {
                _bibliotekaManager17455.AddKnjiga(new Knjiga
                {
                    Naslov = "Naslov1",
                    GodinaIzdanja = 1233,
                    ISBN = "ISBN-13 978-3-642-11746-" + i.ToString(),
                    SpisakAutora = (new List<string>(3)).Select(x => "Autor " + i.ToString()).ToList(),
                    Taken = false,
                    Zanr = "Zanr" + i.ToString()
                });
                
                if (i <= 4)
                {
                    _bibliotekaManager17455.AddClan(new Student
                    {
                        Ime = "Ime" + i.ToString(),
                        Prezime = "Prezime" + i.ToString(),
                        Cash = NumberGenerator.GetRandomNumber(10, 1000),
                        DatumRodjenja = new DateTime(1996, 7, i),
                        Index = (17455 + i).ToString(),
                        Level = (Student.Levels)(i % 2),
                        State = States.OK,
                        MaticniBroj = "123456789123" + i.ToString(),
                        Comment = ""
                    });
                }
            }
        }
    }
}
