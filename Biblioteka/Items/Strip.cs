using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Strip : Knjiga
    {
        public string AnimatorskaKuca { get; set; }

        public List<string> SpisakUmjetnika { get; set; }

        public int BrojIzdanja { get; set; }

        public bool Specijalno { get; set; }

        public override Knjiga GetValid(bool force = false)
        {
            base.PromptInput();

            Console.Write("Unesite naziv animatorske kuce: ");
            AnimatorskaKuca = Console.ReadLine();

            string buffer = "" ;
            Console.WriteLine("Unesite umjetnike ('\\n' za kraj):");
            while (buffer != "\n")
            {
                buffer = Console.ReadLine();

                if (buffer != "\n")
                    SpisakUmjetnika.Add(buffer);
            }

            Console.Write("Unesite broj izdanja: ");
            BrojIzdanja = Parser.GetNextNumber();

            Console.Write("Je li specijalno izdanje? (Y/N)");
            char prompt;
            while ((prompt = (char)Console.Read()) != 'Y' && (prompt != 'N'))
                Console.Write("Unos nije validan: ");

            Specijalno = (prompt == 'Y');

            return this;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Animatorska kuca: {0}", AnimatorskaKuca);
            Console.WriteLine("Spisak umjetnika:");
            foreach (string umjetnik in SpisakUmjetnika)
                Console.WriteLine(umjetnik);
            Console.WriteLine("Broj izdanja: {0}", BrojIzdanja);
            Console.WriteLine("Specijalno: {0}", Specijalno ? "Jeste" : "Nije");
        }
    }
}
