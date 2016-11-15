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

        public override void PromptInput()
        {
            base.PromptInput();
            Console.Write("Unesite WorkID: ");
            WorkerID = Console.ReadLine();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("WorkerID: {0}", WorkerID);
        }
    }
}
