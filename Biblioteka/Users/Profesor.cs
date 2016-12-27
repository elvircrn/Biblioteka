using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Biblioteka.Users
{
    public sealed class Profesor : Clan
    {
        public string UniWorkerID { get; set; }

        public override double Popust
        {
            get { return 0.15; }
        }

        public Bitmap ProfileImage { get; set; }
    }
}
