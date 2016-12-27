using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Users
{
    public interface IWorker
    {
        string WorkerID { get; set; }

        Bitmap ProfileImage { get; set; }

        string Occupation { get; set; }
        
        double Salary { get; set; }
    }
}
