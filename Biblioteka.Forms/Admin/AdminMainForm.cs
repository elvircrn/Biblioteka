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
    public partial class AdminMainForm : Form
    {
        DataAPI data;

        public AdminMainForm()
        {
            InitializeComponent();
        }

        public AdminMainForm(DataAPI data) : this()
        {
            this.data = data;
        }

        void LoadClanovi()
        {
            data.ClanAPI.GetClans()
                        .ForEach(x =>
                        {
                            User u = (User)x;
                            clanoviDataGrid.Rows.Add(
                                x.Sifra,
                                u.Ime,
                                u.Prezime,
                                u.Email,
                                x.Comment);
                        });
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            LoadClanovi();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void dodajWorker_Click(object sender, EventArgs e)
        {

        }
    }
}
