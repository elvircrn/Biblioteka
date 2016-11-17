using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;

namespace Biblioteka.Model
{
    public class NaucniRad : Knjiga, INaucniRad
    {
        private string _oblikReferenciranja;
        private string _oblastNauke;

        public string Konferencija { get; set; }

        public string GeneralneInformacije()
        {
            return String.Format("Naslov: {0}\nKonferencija: {1}\nOblast nauke: {2}\nOblik referenciranja: {3}\n", Naslov, Konferencija, OblastNauke(), OblikReferenciranja());
        }

        public List<string> AutoriRada()
        {
            return SpisakAutora;
        }

        public string OblastNauke()
        {
            return _oblastNauke;
        }

        public string OblikReferenciranja()
        {
            return _oblikReferenciranja;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine(GeneralneInformacije());
        }

        protected override Knjiga PromptInput()
        {
            base.PromptInput();

            Console.Write("Unesite oblik referenciranja: ");
            _oblikReferenciranja = Console.ReadLine();
            
            Console.Write("Unesite oblast nauke: ");
            _oblastNauke = Console.ReadLine();

            Console.Write("Unesite konferenciju: ");
            Konferencija = Console.ReadLine();

            return this;
        }
    }
}
