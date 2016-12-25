using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Users
{
    public sealed class Profesor : Clan, IWorker
    {
        public string WorkerID { get; set; }

        public override double Popust
        {
            get { return 0.15; }
        }
    }
}
