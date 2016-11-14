using Biblioteka.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Knjiga
    {
        public string Naslov { get; set; }

        public List<string> SpisakAutora { get; set; }

        public string Sifra { get; set; }

        public string Zanr { get; set; }

        public int GodinaIzdanja { get; set; }

        public string ISBN { get; internal set; }

        public Knjiga()
        {
            SpisakAutora = new List<string>();
        }

        protected virtual Knjiga PromptInput()
        {
            Console.Clear();
            Console.Write("Unesi naslov: ");
            Naslov = Console.ReadLine();

            string buffer = "a";
            Console.WriteLine("Spisak autora('\\n' za kraj)");
            do
            {
                buffer = Console.ReadLine();
                if (buffer != "")
                    SpisakAutora.Add(buffer);
            } while (buffer != "");

            Console.Write("Unesite zanr: ");
            Zanr = Console.ReadLine();

            Console.Write("Unesite godinu izdanja: ");
            GodinaIzdanja = Parser.GetNextNumber(true);

            Console.Write("Unesite validan ISBN: ");
            while (!KnjigaValidator.IsISBNValid(ISBN = Console.ReadLine()))
                Console.Write("Unesite validan ISBN: ");

            return this;
        }

        public virtual Knjiga GetValid(bool force = false)
        {
            PromptInput();

            if (force)
            {
                List<string> errorMessages;
                while (!this.IsValid(out errorMessages))
                {
                    Console.WriteLine("Input nije validan zato sto:");
                    foreach (var error in errorMessages)
                        Console.WriteLine(error);
                    PromptInput();
                }
            }

            return this;
        }

        public virtual void Print()
        {
            Console.WriteLine("Naslov: {0}", Naslov);
            Console.WriteLine("Spisak autora\n");
            foreach (string autor in SpisakAutora)
                Console.WriteLine("    " + autor);
        }
    }
}
