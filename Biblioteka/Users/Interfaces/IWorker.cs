using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public interface IWorker
    {
        string WorkerId { get; set; }

        string Occupation { get; set; }
        
        double Salary { get; set; }
    }
}
