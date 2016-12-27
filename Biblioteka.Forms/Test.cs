using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka.Forms
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void imagePicker1_Load(object sender, EventArgs e)
        {


            Graphics mojGrafickiObjekat; // Kreiranje vlastitog Graphics objekta
            mojGrafickiObjekat = pictureBox1.CreateGraphics();
            Pen mojPen = new Pen(System.Drawing.Color.Blue, 5); // Kreiranje Pen objekta
            SolidBrush mojBrush = new SolidBrush(System.Drawing.Color.Yellow);
            Point[] polygonTacke = new Point[5]; // Definisanje niza tačaka
            polygonTacke[0] = new Point(113, 283);
            polygonTacke[1] = new Point(70, 156);
            polygonTacke[2] = new Point(180, 70);
            polygonTacke[3] = new Point(290, 156);
            polygonTacke[4] = new Point(250, 283);
            mojGrafickiObjekat.DrawPolygon(mojPen, polygonTacke); // Crtanje poligona
            mojGrafickiObjekat.DrawLines(mojPen, polygonTacke); // Crtanje linija
            mojGrafickiObjekat.FillPolygon(mojBrush, polygonTacke); // Crtanje punog poligona

        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
