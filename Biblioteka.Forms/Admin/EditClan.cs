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
    public partial class EditClan : Form
    {
        private DataAPI _data;
        private Clan _clan;

        public EditClan()
        {
            InitializeComponent();
        }

        public EditClan(DataAPI data, Clan clan) : this()
        {
            _data = data;
            _clan = clan;
        }

        private void EditClan_Load(object sender, EventArgs e)
        {
            LoadZaduzenja();
        }

        void LoadZaduzenja()
        {
            foreach (var item in _data.BibliotekaAPI.GetZaduzenja(_clan))
            {
                TreeNode node = treeView1.Nodes.Add(item.Item1.Naslov + " (" + item.Item1.GodinaIzdanja.ToString());
                TreeNode spisakAutoraNode = node.Nodes.Add("Spisak autora");
                foreach (string autor in item.Item1.SpisakAutora)
                    spisakAutoraNode.Nodes.Add(autor);
                node.Nodes.AddRange(new TreeNode[]
                {
                    new TreeNode("Datum isteka: " + item.Item2.ToString()),
                    new TreeNode("Zanr: " + item.Item1.Zanr),
                    new TreeNode("ISBN: " + item.Item1.ISBN)
                });

                if (item.Item1 is Strip)
                {
                    Strip strip = (Strip)item.Item1;
                    node.Nodes.AddRange(new TreeNode[]
                    {
                        new TreeNode("Animatorska kuca: " + item.Item1.Zanr),
                        new TreeNode("Broj izdanja: " + item.Item1.ISBN)
                    });
                }
                else if (item.Item1 is NaucniRad)
                {
                    NaucniRad naucniRad = (NaucniRad)item.Item1;
                    node.Nodes.AddRange(new TreeNode[]
                    {
                        new TreeNode("Informacije: " + naucniRad.GeneralneInformacije()),
                    });
                }
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
