using Biblioteka.Model;
using Biblioteka.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;

namespace Biblioteka.Users
{
    public class Student : Clan
    {
        public enum Levels { Bachelor = 1, Master };

        public string Index { get; set; }

        public Levels Level { get; set; }

        public override double Popust
        {
            get { return (Level == Levels.Bachelor) ? 0.1 : 0.125; }
        }
    }
}
