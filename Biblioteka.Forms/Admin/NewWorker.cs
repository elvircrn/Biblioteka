using Biblioteka.Common.Security;
using Biblioteka.Common.Validation;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka.Forms.Admin
{
    public partial class NewWorker : Form
    {
        public Worker Worker { get; set; }

        private DataAPI _data;

        public NewWorker()
        {
            InitializeComponent();
        }

        public NewWorker(DataAPI data) : this()
        {
            _data = data;
            comboBox1.Items.AddRange(new string[] { "Bibliotekar", "Tech" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valid = true;

            toolStripStatusLabel1.Text = "";

            Worker workerTmp = new Worker();
            workerTmp.Ime = textBox1.Text;
            workerTmp.Prezime = textBox2.Text;
            workerTmp.Email = textBox7.Text;
            workerTmp.DatumRodjenja = dateTimePicker1.Value;
            workerTmp.MaticniBroj = textBox4.Text;
            workerTmp.UserName = textBox5.Text;

            if (String.IsNullOrWhiteSpace(textBox1.Text) ||
                String.IsNullOrWhiteSpace(textBox2.Text) ||
                String.IsNullOrWhiteSpace(textBox4.Text) ||
                String.IsNullOrWhiteSpace(textBox5.Text)
                )
            {
                toolStripStatusLabel1.Text += "; Zabranjeno unositi prazna polja";
            }

            if (textBox3.Text != textBox6.Text)
            {
                toolStripStatusLabel1.Text += "; Passwordi se ne poklapaju";
                valid = false;
            }

            if (!UserValidator.ValidateMaticni(workerTmp.MaticniBroj))
            {
                toolStripStatusLabel1.Text += "; Maticni nije validan";
                valid = false;
            }

            if (workerTmp.DatumRodjenja > DateTime.Now)
            {
                toolStripStatusLabel1.Text += "; Datum rodjenja nije validan";
                valid = false;
            }

            workerTmp.PasswordHash = Hash.Encode(textBox3.Text);

            if (_data.UserAPI.UsernameTaken(workerTmp.UserName))
                toolStripStatusLabel1.Text += "; Username vec postoji";

            if (comboBox1.SelectedIndex == 0)
                workerTmp.Roles.Add((Role)_data.RoleAPI.GetRoleByName("WORKER"));

            if (valid)
            {
                Worker = workerTmp;
                this.Close();
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewWorker_Load(object sender, EventArgs e)
        {
            imagePicker1.Visible = true;
        }

        private void imagePicker1_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
