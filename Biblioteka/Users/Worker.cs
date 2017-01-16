using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Worker : User, IWorker
    {
        [Key]
        public int WorkerId { get; set; }

        public int? ImageDataId { get; set; }
        [ForeignKey("ImageDataId")]
        public ImageData ImageData { get; set; }

        public string Occupation { get; set; }

        public string WorkerID { get; set; }

        public double Salary { get; set; }

        public override string ToString()
        {
            return base.ToString() + Occupation;
        }
    }
}
