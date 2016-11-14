using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Users
{
    public sealed class Profesor : User, IWorker
    {
        public string WorkerID { get; set; }

        public override double Popust
        {
            get { return 0.15; }
        }

        public override object Clone()
        {
            return new Profesor 
            {
                Ime = Ime,
                Prezime = Prezime,
                MaticniBroj = MaticniBroj,
                DatumRodjenja = DatumRodjenja,
                Comment = Comment,
                Sifra = Sifra,
                WorkerID = WorkerID
            };
        }

        public override void PromptInput()
        {
            base.PromptInput();
            Console.Write("Unesite WorkID: ");
            WorkerID = Console.ReadLine();
        }
    }
}
