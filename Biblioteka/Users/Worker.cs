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
    // XML - Ready
    // Binary - not ready
    public class Worker : User, IWorker
    {
        [Key]
        [StringLength(200)]
        public string WorkerId { get; set; }

        public int? ImageDataId { get; set; }
        [ForeignKey("ImageDataId")]
        public ImageData ImageData { get; set; }

        [StringLength(200)]
        public string Occupation { get; set; }

        public double Salary { get; set; }

        public override string ToString()
        {
            return base.ToString() + Occupation;
        }
    }
}
