using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;

namespace Biblioteka.Model
{
    public class Strip : Knjiga
    {
        public string AnimatorskaKuca { get; set; }

        public List<string> SpisakUmjetnika { get; set; }

        public int BrojIzdanja { get; set; }

        public bool Specijalno { get; set; }

        public override string ToString()
        {
            string ret = base.ToString();
            ret += AnimatorskaKuca;
            foreach (string spisakUmjetnika in SpisakUmjetnika)
                ret += spisakUmjetnika;
            return ret;
        }
    }
}
