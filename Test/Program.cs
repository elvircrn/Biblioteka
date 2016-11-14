using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Biblioteka.Model;
using Biblioteka;
using Biblioteka.Validation;

namespace Test
{
    class Program
    {
        private enum Menus { RegDelClan, Main, Hello, Izlaz, KnjigaInput, RegDelKnjiga, ClanInput, IznajmiVrati, Analiza, Pretraga, RegKnjiga, DelKnjiga, RegClan, DelClan, IznKnjigu, VraKnjigu, PoISBN, PoNazivu };

        static Stack<Menus> History { get; set; }

        private static Menus CurrentMenu { get; set; }
        private static int Index { get; set; }
        private static string Buffer { get; set; }

        private static BibliotekaManager _bibliotekaManager;

        private static void Nazad(bool ClearCurrent = false)
        {
            if (ClearCurrent)
                History.Pop();

            if (History.Count == 0)
                throw new Exception("Can't go back");
            CurrentMenu = History.Peek();
            History.Pop();
        }

        private static void Render()
        {
            if (CurrentMenu == Menus.Hello)
            {
                Console.Write("Dobro došli u " + _bibliotekaManager.Ime + " biblioteku!\n");
            }
            else if (CurrentMenu == Menus.Main)
            {
                Console.Write("1.Registruj / Briši knjigu\n" +
                              "2.Registruj / Briši člana\n" +
                              "3.Iznajmi / Vrati knjigu\n" +
                              "4.Pretraga\n" +
                              "5.Analiza sadržaja\n" +
                              "6.Izlaz\n");
            }
            else if (CurrentMenu == Menus.RegDelKnjiga)
            {
                Console.Write("1.Registruj Knjigu\n" +
                              "2.Briši knjigu\n" +
                              "3.Nazad\n");
            }
            else if (CurrentMenu == Menus.RegDelClan)
            {
                Console.Write("1.Registruj clana\n" +
                              "2.Briši clana\n" +
                              "3.Nazad\n");
            }
            else if (CurrentMenu == Menus.IznajmiVrati)
            {
                Console.Write("1.Iznajmi knjigu\n" +
                              "2.Vrati knjigu\n" +
                              "3.Nazad\n");
            }
            else if (CurrentMenu == Menus.IznKnjigu)
            {
                CollectInput();
            }
            else if (CurrentMenu == Menus.VraKnjigu)
            {
                CollectInput();
            }
            else if (CurrentMenu == Menus.RegKnjiga)
            {
                Console.WriteLine("Koji tip?");
                Console.WriteLine("1. Knjiga");
                Console.WriteLine("2. Naucni rad");
                Console.WriteLine("3. Knjiga");
            }
            else if (CurrentMenu == Menus.DelKnjiga)
            {
                throw new NotImplementedException("Pitaj asistenta");
            }
            else if (CurrentMenu == Menus.Pretraga)
            {
                Console.Write("1.Po ISBN\n" +
                              "2.Po Naizvu\n" +
                              "3.Nazad\n");
            }
            else if (CurrentMenu == Menus.PoNazivu)
            {
                Console.Write("Unesite naziv: ");
            }
            else if (CurrentMenu == Menus.PoISBN)
            {
                Console.Write("Unesite ISBN: ");
            }
        }

        private static bool ValidateInput()
        {
            return false;
        }

        private static void CollectInput()
        {
            if (CurrentMenu == Menus.Main ||
                CurrentMenu == Menus.RegDelKnjiga ||
                CurrentMenu == Menus.RegDelClan ||
                CurrentMenu == Menus.Pretraga ||
                CurrentMenu == Menus.IznajmiVrati ||
                CurrentMenu == Menus.RegKnjiga)
            {
                bool ok = true;
                do
                {
                    ok = true;
                    try
                    {
                        Index = Parser.GetNextNumber();
                    }
                    catch (Exception e)
                    {
                        ok = false;
                        Console.WriteLine("Invalid input\n");
                    }
                } while (!ok);
            }
            else if (CurrentMenu == Menus.PoISBN ||
                     CurrentMenu == Menus.PoNazivu)
            {
                Buffer = Console.ReadLine();
            }
            else if (CurrentMenu == Menus.KnjigaInput)
            {
                List<string> errorMessages;
                Knjiga knjiga = new Knjiga();

                knjiga.PromptInput();

                while (!knjiga.IsValid(out errorMessages))
                {
                    Console.WriteLine("Input nije validan zato sto:\n");
                    foreach (var error in errorMessages)
                        Console.WriteLine(error);
                    knjiga.PromptInput();
                }

                _bibliotekaManager.AddKnjiga(knjiga);
            }
        }

        public static void DoStuff()
        {

        }

        private static void ProcessInput()
        {
            if (CurrentMenu == Menus.Izlaz)
                System.Environment.Exit(0);
            else if (CurrentMenu == Menus.Main)
            {
                History.Push(CurrentMenu);
                if (Index == 1)
                    CurrentMenu = Menus.RegDelKnjiga;
                else if (Index == 2)
                    CurrentMenu = Menus.RegDelClan;
                else if (Index == 3)
                    CurrentMenu = Menus.IznajmiVrati;
                else if (Index == 4)
                    CurrentMenu = Menus.Pretraga;
                else if (Index == 5)
                    CurrentMenu = Menus.Analiza;
                else if (Index == 6)
                    CurrentMenu = Menus.Izlaz;
            }
            else if (CurrentMenu == Menus.RegDelKnjiga)
            {
                History.Push(CurrentMenu);
                if (Index == 1)
                    CurrentMenu = Menus.RegKnjiga;
                else if (Index == 2)
                    CurrentMenu = Menus.DelKnjiga;
                else if (Index == 3)
                    Nazad(true);
            }
            else if (CurrentMenu == Menus.RegKnjiga)
            {
                Knjiga knjiga = new Knjiga();
                knjiga.PromptInput();

                _bibliotekaManager.AddKnjiga(knjiga);
            }
            else if (CurrentMenu == Menus.DelKnjiga)
            {
                History.Push(CurrentMenu);
                throw new NotImplementedException("Pitaj asistenta");
            }
            else if (CurrentMenu == Menus.RegDelClan)
            {
                History.Push(CurrentMenu);
                if (Index == 1)
                    CurrentMenu = Menus.RegClan;
                else if (Index == 2)
                    CurrentMenu = Menus.DelClan;
                else if (Index == 3)
                    Nazad(true);
            }
            else if (CurrentMenu == Menus.RegClan)
            {
                throw new NotImplementedException("Pitaj asistenta");
            }
            else if (CurrentMenu == Menus.DelClan)
            {
                throw new NotImplementedException("Pitaj asistenta");
            }
            else if (CurrentMenu == Menus.IznajmiVrati)
            {
                History.Push(CurrentMenu);
                if (Index == 1)
                    CurrentMenu = Menus.IznKnjigu;
                else if (Index == 2)
                    CurrentMenu = Menus.VraKnjigu;
                else if (Index == 3)
                    Nazad(true);
            }
            else if (CurrentMenu == Menus.Pretraga)
            {
                History.Push(CurrentMenu);
                if (Index == 1)
                    CurrentMenu = Menus.PoISBN;
                else if (Index == 1)
                    CurrentMenu = Menus.PoNazivu;
                else if (Index == 3)
                    Nazad(true);
            }
            else if (CurrentMenu == Menus.IznKnjigu)
            {
                throw new NotImplementedException("Pitaj asistenta");
            }
            else if (CurrentMenu == Menus.VraKnjigu)
            {
                throw new NotImplementedException("Pitaj asistenta");
            }
            else if (CurrentMenu == Menus.PoISBN)
            {

            }
            else if (CurrentMenu == Menus.PoNazivu)
            {
                throw new NotImplementedException("Pitaj asistenta");
            }
            else if (CurrentMenu == Menus.Analiza)
            {
                throw new NotImplementedException("Pitaj asistenta");
            }
            else if (CurrentMenu == Menus.RegKnjiga)
            {

            }

            Console.Clear();
        }

        static void Main(string[] args)
        {
            Init();

            Render();
            CurrentMenu = Menus.Main;

            while (true)
            {
                Render();
                CollectInput();
                ProcessInput();
            }
        }

        private static void Init()
        {
            _bibliotekaManager = new BibliotekaManager("Crnjo");
            History = new Stack<Menus>();
            CurrentMenu = Menus.Hello;
        }
    }
}
