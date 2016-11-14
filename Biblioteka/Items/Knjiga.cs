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

        public Knjiga PromptInput()
        {
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

            Console.Write("Unesite ISBN");
            ISBN = Console.ReadLine();

            return this;
        }
    }
}
