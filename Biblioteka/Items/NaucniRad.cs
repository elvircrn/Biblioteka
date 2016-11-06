using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class NaucniRad : Knjiga, INaucniRad
    {
        public string Konferencija { get; set; }

        public string OblastNauke { get; set; }

        public string generalneInformacije()
        {
            throw new NotImplementedException();
        }

        public List<string> autoriRada()
        {
            throw new NotImplementedException();
        }

        public string oblastNauke()
        {
            throw new NotImplementedException();
        }

        public string oblikReferenciranja()
        {
            throw new NotImplementedException();
        }
    }
}
