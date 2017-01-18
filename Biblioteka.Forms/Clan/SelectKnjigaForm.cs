using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteka.BLL.Interfaces;
using Biblioteka.Model;

namespace Biblioteka.Forms
{
    public partial class SelectKnjigaForm : Form
    {
        private DataAPI data;

        public Knjiga SelectedKnjiga { get; set; }

        List<Knjiga> knjige;

        public delegate bool Restriction(Knjiga knjiga);

        private Restriction _restriction;

        private bool taut(Knjiga knjiga) { return true; }

        public SelectKnjigaForm()
        {
            InitializeComponent();
            SelectedKnjiga = null;
        }

        public SelectKnjigaForm(DataAPI data, Restriction restriction = null) : this()
        {
            _restriction = restriction ?? taut;
            this.data = data;
        }

        private void NewWishListItemControl_Load(object sender, EventArgs e)
        {
            knjigeSearchResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void pretragaButton_Click(object sender, EventArgs e)
        {
            knjigeSearchResult.Rows.Clear();

            knjige = data.KnjigaAPI.SearchByKeyword(searchText.Text)
                                   .Where(x => _restriction(x) 
                                   && (data.SessionAPI.CurrentClan == null || !(data.SessionAPI.CurrentClan.WishList?.Contains(x) ?? false)))
                                   .ToList();

            knjige.ForEach(x => knjigeSearchResult.Rows.Add(
                          x.Naslov,
                          x.SpisakAutora.FirstOrDefault(),
                          x.GodinaIzdanja.ToString()
                  ));
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SelectedKnjiga = knjige[knjigeSearchResult.SelectedRows[0].Index];
            this.Close();
        }

        private void knjigeSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
