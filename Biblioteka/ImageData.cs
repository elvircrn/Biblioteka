using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class ImageData
    {
        public DateTime ImageDate { get; set; }

        public Bitmap Image { get; set; }

        public ImageData()
        {
        }

        public ImageData(Bitmap Image, DateTime? ImageDate = null)
        {
            if (ImageDate == null)
                ImageDate = DateTime.Now;
            this.Image = Image;
        }
    }
}
