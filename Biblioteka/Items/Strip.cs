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
    }
}
