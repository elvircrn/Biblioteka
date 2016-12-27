using Biblioteka.BLL.Managers;
using Biblioteka.Common;
using Biblioteka.Users;
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
    public partial class LogInForm : Form
    {
        private DataAPI data;

        public LogInForm()
        {
            InitializeComponent();
        }

        public LogInForm(DataAPI dataAPI) : this()
        {
            this.data = dataAPI;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            data.SessionAPI.CurrentUser = data.UserAPI.LogIn(usernameTextBox.Text, passwordTextBox.Text);

            if (data.SessionAPI.CurrentUser == null)
            {
                MessageBox.Show("Username or password not valid");
                return;
            }

            if (data.SessionAPI.CurrentUser.IsInRole(RoleManager.CLAN))
            {
                ClanHomeForm clForm = new ClanHomeForm(data);
                clForm.Show();
                clForm.Activate();
                clForm.BringToFront();
                clForm.FormClosed += delegate { this.Show(); };
                this.Hide();
            }
            else if (data.SessionAPI.CurrentUser.IsInRole(RoleManager.ADMIN) ||
                     data.SessionAPI.CurrentUser.IsInRole(RoleManager.WORKER))
            {
                AdminMainForm adminForm = new AdminMainForm(data);
                adminForm.Show();
                adminForm.Activate();
                adminForm.BringToFront();
                adminForm.FormClosed += delegate { this.Show(); };
                this.Hide();
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            this.FormClosed += delegate
            {
                Application.Exit();
            };

            Redraw();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            System.Drawing.Graphics formGraphics = e.Graphics;
            string drawString = "Biblioteka dobrinja - Mi povezujemo ideje";
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = this.Width / 2 - 120;
            float y = this.Height / 2;
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();

            if (_points != null)
            {
                float scale = Math.Min(ClientSize.Width, ClientSize.Height);

                e.Graphics.ScaleTransform(scale, scale);

                using (Pen pen = new Pen(Color.Red, 1 / scale))
                {
                    e.Graphics.DrawLines(pen, _points.Select(p => new PointF(p.X * 2.0f, p.Y * 2.0f))
                                                     .Where(p => (p.X < 0.5 || 1.4 < p.X))
                                                     .ToArray());

                }


            }


        }


        private PointF[] _points;

        private void Redraw()
        {
            List<PointF> points = new List<PointF>();

            GenerateHilbert(new PointF(0, 0), 1, 0, 0, 1, 8, points);
            _points = points.ToArray();
            Invalidate();
        }

        private void GenerateHilbert(PointF origin, float xi, float xj, float yi, float yj, int depth, List<PointF> points)
        {
            if (depth <= 0)
            {
                PointF current = origin + new SizeF((xi + yi) / 2, (xj + yj) / 2);
                points.Add(current);
            }
            else
            {
                GenerateHilbert(origin, yi / 2, yj / 2, xi / 2, xj / 2, depth - 1, points);
                GenerateHilbert(origin + new SizeF(xi / 2, xj / 2), xi / 2, xj / 2, yi / 2, yj / 2, depth - 1, points);
                GenerateHilbert(origin + new SizeF(xi / 2 + yi / 2, xj / 2 + yj / 2), xi / 2, xj / 2, yi / 2, yj / 2, depth - 1, points);
                GenerateHilbert(origin + new SizeF(xi / 2 + yi, xj / 2 + yj), -yi / 2, -yj / 2, -xi / 2, -xj / 2, depth - 1, points);
            }



        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Invalidate();
        }

        public void DrawString(string text)
        {
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
