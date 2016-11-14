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

        public string GeneralneInformacije()
        {
            throw new NotImplementedException();
        }

        public List<string> AutoriRada()
        {
            throw new NotImplementedException();
        }

        public string OblastNauke()
        {
            throw new NotImplementedException();
        }

        public string OblikReferenciranja()
        {
            throw new NotImplementedException();
        }
    }
}
