using Biblioteka.Model;
using Biblioteka.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Users
{
    public class Student : User
    {
        public enum Levels { Bachelor = 1, Master };

        public string Index { get; set; }

        public Levels Level { get; set; }

        public override double Popust
        {
            get { return (Level == Levels.Bachelor) ? 0.1 : 0.125; }
        }

        public override object Clone()
        {
            return new Student
            {
                Ime = Ime,
                Prezime = Prezime,
                MaticniBroj = MaticniBroj,
                DatumRodjenja = DatumRodjenja,
                Comment = Comment,
                Sifra = Sifra,
                Index = Index,
                Level = Level
            };
        }

        public override void PromptInput()
        {
            base.PromptInput();

            Console.WriteLine("Unesite nivo studija:");
            Console.WriteLine("1. Bachelor");
            Console.WriteLine("2. Master");

            int index = Parser.GetNextNumber(true, 1, 2);

            Level = (Levels)index;

            Console.Write("Unesite index: ");
            Index = Console.ReadLine();

            while (!StudentValidator.IsIndexValid(Index))
            {
                Console.WriteLine("Index nije validan, unesite ponovo: ");
                Index = Console.ReadLine();
            }
        }
    }
}
