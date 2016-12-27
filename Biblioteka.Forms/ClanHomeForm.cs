using Biblioteka.BLL.Interfaces;
using Biblioteka.BLL.Managers.Interfaces;
using Biblioteka.Forms;
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
    public partial class ClanHomeForm : Form
    {
        private NewWishListItemForm AddWishListItemControl;
        private DataAPI data;

        public ClanHomeForm()
        {
            InitializeComponent();
            InitComponents();
        }
        public ClanHomeForm(DataAPI data) : this()
        {
            this.data = data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadZaduzenja()
        {
            var debts = data.BibliotekaAPI.GetZaduzenja(data.SessionAPI.CurrentClan);
            foreach (var debt in debts)
            {
                zaduzenjaGrid.Rows.Add(
                 debt.Item1.Sifra,
                 debt.Item1.Naslov,
                 debt.Item1.SpisakAutora.FirstOrDefault(),
                 debt.Item1.Zanr,
                 debt.Item2
                );
            }
        }

        private void LoadWishList()
        {
            
        }

        private void InitZaduzenja()
        {

        }

        private void InitComponents()
        {
            InitWish();
            InitZaduzenja();
        }

        private void InitWish()
        {
            wishCheckList.ContextMenu = new ContextMenu();
            wishCheckList.ContextMenu.MenuItems.AddRange(new MenuItem[] {
                    new MenuItem("Add item")
                }
            );

            wishCheckList.ContextMenu.MenuItems[0].Click += AddWishListItem;
        }

        private void AddWishListItem(object sender, EventArgs e)
        {
            NewWishListItemForm wishListForm = new NewWishListItemForm(data);

            wishListForm.Show();
            
            wishListForm.FormClosing += delegate 
            {
                if (wishListForm.SelectedKnjiga != null)
                {
                    wishCheckList.Items.Add(wishListForm.SelectedKnjiga.Naslov + ", " + wishListForm.SelectedKnjiga.SpisakAutora.FirstOrDefault() ?? "");
                    data.SessionAPI.CurrentClan.WishList.Add(wishListForm.SelectedKnjiga);
                }
            };
        }

        private void ClanHomeForm_Load(object sender, EventArgs e)
        {
            LoadZaduzenja();
        }

        private void wishCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void wishContext_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            data.SessionAPI.CurrentUser = null;
            this.Close();
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
