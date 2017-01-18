using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Model
{
    public class NaucniRad : Knjiga, INaucniRad
    {
        [StringLength(200)]
        private string _oblikReferenciranja;
        [StringLength(200)]
        private string _oblastNauke;

        [StringLength(200)]
        public string Konferencija { get; set; }

        public string GeneralneInformacije()
        {
            return String.Format("Naslov: {0}\nKonferencija: {1}\nOblast nauke: {2}\nOblik referenciranja: {3}\n", Naslov, Konferencija, OblastNauke(), OblikReferenciranja());
        }

        public List<string> AutoriRada()
        {
            return SpisakAutora.Select(x => x.Name).ToList();
        }

        public string OblastNauke()
        {
            return _oblastNauke;
        }

        public string OblikReferenciranja()
        {
            return _oblikReferenciranja;
        }

        public override string ToString()
        {
            return base.ToString() + GeneralneInformacije();
        }

        public bool IsSame(NaucniRad naucniRad)
        {
            return true;
        }
    }
}