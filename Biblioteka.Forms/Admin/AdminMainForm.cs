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

        public AdminMainForm(DataAPI data) : this()
        {
            this._data = data;
            if (!_data.SessionAPI.CurrentUser.IsInRole("ADMIN"))
                Bibliotekar.TabPages.Remove(tabPage2);
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

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            if (_data.SessionAPI.CurrentUser.IsInRole("ADMIN"))
                LoadWorkers();
            LoadClanovi();
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
            editClanForm.ShowDialog();
        }
    }
}