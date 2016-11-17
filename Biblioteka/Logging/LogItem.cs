using Biblioteka.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class LogItem 
    {
        public enum Action { Posudio, Vratio, Uclanio, Registrovao };

        public Action LogAction { get; set; }

        public DateTime DateTime { get; set; }

        public Knjiga Knjiga { get; set; }

        public IClan Clan { get; set; }
    }
}
