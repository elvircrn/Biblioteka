using Biblioteka.Users;
using Biblioteka.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class User : IClan
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string MaticniBroj { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public virtual double Popust
        {
            get { return 0; }
        }

        public string Comment { get; set; }

        public string Sifra { get; set; }

        public States State { get; set; }

        public double Cash { get; set; }

        public User()
        {
            State = States.OK;
            Cash = NumberGenerator.GetRandomNumber(10, 1000);
        }

        public virtual void Print()
        {
            Console.WriteLine("Ime: {0}", Ime);
            Console.WriteLine("Prezime: {0}", Prezime);
            Console.WriteLine("Maticni broj: {0}", MaticniBroj);
            Console.WriteLine("Sifra: {0}", Sifra);
            Console.WriteLine("Comment: {0}", Comment);
            Console.WriteLine("Cash: {0}", Cash);
        }

        public virtual void PromptInput()
        {
            Console.Clear();
            Console.Write("Unesite ime: ");
            Ime = Console.ReadLine();

            Console.Write("Unesite prezime: ");
            Prezime = Console.ReadLine();

            Console.Write("Unesite datum rodjenja (npr. 30.07.1996): ");
            DateTime dateTime;

            if (!DateTime.TryParseExact(Console.ReadLine(),
                                   "dd.MM.yyyy", 
                                   CultureInfo.InvariantCulture, 
                                   DateTimeStyles.None, 
                                   out dateTime))
            {
                do
                {
                    Console.Write("Datum nije validan, unesite ponovo: ");
                } while (!DateTime.TryParseExact(Console.ReadLine().Replace('\n', '\0'),
                                   "dd.MM.yyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dateTime));
            }

            DatumRodjenja = dateTime;

            Console.Write("Unesite maticni broj: ");
            MaticniBroj = Console.ReadLine();

            while (!UserValidator.ValidateMaticni(MaticniBroj))
            {
                Console.Write("Maticni nije validan, unesite ponovo: ");
                MaticniBroj = Console.ReadLine();
            }
        }
    }
}
