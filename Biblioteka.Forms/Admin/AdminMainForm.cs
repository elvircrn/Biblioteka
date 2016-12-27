﻿using Biblioteka.Common;
using Biblioteka.Forms.Admin;
using Biblioteka.Model;
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
        DataAPI _data;

        List<string> _workerIds;
        List<string> _clanIds;

        public AdminMainForm()
        {
            _workerIds = new List<string>();
            _clanIds = new List<string>();
            InitializeComponent();
        }

        void LoadKnjige()
        {
            treeView1.Nodes.Clear();
            foreach (var item in _data.KnjigaAPI.GetKnjige())
            {
                ContextMenu bookCM;
                bookCM = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("Izbrisi"),
                    new MenuItem("Kloniraj")
                });

                TreeNode node = treeView1.Nodes.Add(item.Naslov + " (" + item.GodinaIzdanja.ToString());
                node.ContextMenu = bookCM;
                node.ContextMenu.MenuItems[0].Click += delegate (object sender, EventArgs e)
                {
                    _data.BibliotekaAPI.RemoveKnjigaById(item.Sifra);
                    treeView1.Nodes.Remove(node);
                };
                node.ContextMenu.MenuItems[1].Click += delegate (object sender, EventArgs e)
                {
                    _data.KnjigaAPI.AddKnjiga(item);
                    LoadKnjige();
                };
                TreeNode spisakAutoraNode = node.Nodes.Add("Spisak autora");
                foreach (string autor in item.SpisakAutora)
                    spisakAutoraNode.Nodes.Add(autor);
                node.Nodes.AddRange(new TreeNode[]
                {
                    new TreeNode("Datum isteka: " + item.ToString()),
                    new TreeNode("Zanr: " + item.Zanr),
                    new TreeNode("ISBN: " + item.ISBN)
                });

                if (item is Strip)
                {
                    Strip strip = (Strip)item;
                    node.Nodes.AddRange(new TreeNode[]
                    {
                        new TreeNode("Animatorska kuca: " + item.Zanr),
                        new TreeNode("Broj izdanja: " + item.ISBN)
                    });
                }
                else if (item is NaucniRad)
                {
                    NaucniRad naucniRad = (NaucniRad)item;
                    node.Nodes.AddRange(new TreeNode[]
                    {
                        new TreeNode("Informacije: " + naucniRad.GeneralneInformacije()),
                    });
                }
            }
        }

        public AdminMainForm(DataAPI data) : this()
        {
            this._data = data;
            if (!_data.SessionAPI.CurrentUser.IsInRole("ADMIN"))
                Bibliotekar.TabPages.Remove(zaposleniciTab);
        }

        void LoadClanovi(string keywords = "")
        {
            clanoviDataGrid.Rows.Clear();
            _clanIds.Clear();
            _data.ClanAPI.GetClans(keywords)
                        .ForEach(x =>
                        {
                            User u = (User)x;
                            _clanIds.Add(x.Sifra);
                            clanoviDataGrid.Rows.Add(
                                x.Sifra,
                                u.Ime,
                                u.Prezime,
                                u.Email,
                                x.Comment,
                                u.Roles.Select(t => t.DisplayName)
                                       .ToList()
                                       .Aggregate((r, t) => r + ", " + t));
                        });
        }

        void InitPie()
        {
            sliceList = _data.BibliotekaAPI.Analyze()
                                           .Select(x => new SliceData
                                           {
                                               share = x.Item1,
                                               clr = Color.FromArgb(NumberGenerator.GetRandomNumber(0, 254),
                                                                    NumberGenerator.GetRandomNumber(0, 254),
                                                                    NumberGenerator.GetRandomNumber(0, 254)),
                                               name = x.Item2
                                           }).ToList();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            if (_data.SessionAPI.CurrentUser.IsInRole("ADMIN"))
                LoadWorkers();
            LoadClanovi();
            LoadKnjige();
            InitPie();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadWorkers(string keywords = "")
        {
            workersDataGrid.Rows.Clear();
            _workerIds.Clear();
            _data.WorkerAPI.GetWorkers(keywords)
            .ForEach(x =>
            {
                Worker u = (Worker)x;
                if (u.IsInRole("ADMIN"))
                    return;
                _workerIds.Add(x.WorkerID);
                workersDataGrid.Rows.Add(
                    u.Ime,
                    u.Prezime,
                    u.Email,
                    u.Roles.Select(t => t.DisplayName)
                           .ToList()
                           .Aggregate(string.Empty, (r, t) => ((r == "") ? string.Empty : r + ", ") + t));
            });

        }

        private void dodajWorker_Click(object sender, EventArgs e)
        {
            NewWorker newWorkerForm = new NewWorker(_data);
            newWorkerForm.FormClosing += delegate
            {
                if (newWorkerForm.Worker != null)
                {
                    _data.WorkerAPI.AddWorker(newWorkerForm.Worker);
                    this.LoadWorkers();
                }
                
            };
            newWorkerForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void workersDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (workersDataGrid.SelectedRows.Count == 0)
                return;

            foreach (DataGridViewRow row in workersDataGrid.SelectedRows)
                _data.WorkerAPI.RemoveWorker(_workerIds[row.Index]);
            LoadWorkers();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadWorkers(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadClanovi(textBox2.Text);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (clanoviDataGrid.SelectedRows.Count == 0)
                return;

            foreach (DataGridViewRow row in clanoviDataGrid.SelectedRows)
                _data.ClanAPI.RemoveClanById(_clanIds[row.Index]);
            LoadClanovi();
        }

        private void clanoviDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void urediClanaButton_Click(object sender, EventArgs e)
        {
            if (clanoviDataGrid.SelectedRows.Count == 0)
                return;

            Clan clan = (Clan)_data.ClanAPI.GetById(_clanIds[clanoviDataGrid.SelectedRows[0].Index]);
            EditClan editClanForm = new EditClan(_data, clan);
            editClanForm.Show();
            editClanForm.FormClosed += delegate
            {
                LoadClanovi();
            };
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        struct SliceData
        {
            public int share;
            public Color clr;
            public string name;
        };

        private Rectangle rect = new Rectangle(250, 150, 200, 200);
        private List<SliceData> sliceList = new List<SliceData>();


        private Color curClr = Color.Black;

        private void DrawPieChart(bool flMode, Graphics g)
        {
            g.Clear(this.BackColor);
            Rectangle rect = new Rectangle(0, 0, 300, 300);
            float angle = 0;
            float sweep = 0;
            int shareTotal = sliceList.Sum(x => x.share);

            int adv = 0;

            foreach (var dt in sliceList)
            {
                sweep = 360f * dt.share / shareTotal;

                if (flMode)
                    g.FillPie(new SolidBrush(dt.clr), rect, angle, sweep);
                else
                    g.DrawPie(new Pen(dt.clr), rect, angle, sweep);
                angle += sweep;

                int y = (adv++) * 10;
                int x = 300;

                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(dt.clr);
                g.FillRectangle(myBrush, new Rectangle(x, y, 10, 10));

                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 7);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                g.DrawString(dt.name, drawFont, drawBrush, x + 20, y, drawFormat);

                y += 20;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawPieChart(true, e.Graphics);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Bibliotekar_Click(object sender, EventArgs e)
        {
            InitPie();
        }

        private void knjigeTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void addClanButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
