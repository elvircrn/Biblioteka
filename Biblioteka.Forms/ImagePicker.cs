using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka.Forms
{
    public partial class ImagePicker : UserControl
    {
        ImageData ImageData { get; set; }

        public ImagePicker()
        {
            InitializeComponent();
            ImageData = new ImageData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        // Slika ne smije biti starija od 3 mjeseca
        private bool ValidateDate(DateTime date)
        {
            int daysDiff = (dateTimePicker1.Value - DateTime.Now).Days;
            return ((new DateTime(0, 0, 0)).AddDays(daysDiff).Month <= 3);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (!ValidateDate(dateTimePicker1.Value))
                errorProvider1.SetError(this, "Unijeti validnu sliku");
            ImageData.ImageDate = dateTimePicker1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrWhiteSpace(ofd.FileName))
            {
                try
                {
                    pictureBox1.BackgroundImage = Image.FromFile(ofd.FileName);
                    ImageData.Image = ImageData.ImageToByte((Bitmap)Image.FromFile(ofd.FileName));
                }
                catch
                {
                    errorProvider1.SetError(this, "Unijeti validnu sliku");
                }
            }
        }

        private void ImagePicker_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
