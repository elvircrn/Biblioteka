namespace Biblioteka.Forms
{
    partial class AdminMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Bibliotekar = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.urediClanaButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.addClanButton = new System.Windows.Forms.Button();
            this.clanoviDataGrid = new System.Windows.Forms.DataGridView();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zaposleniciTab = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.workersDataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dodajWorker = new System.Windows.Forms.Button();
            this.knjigeTab = new System.Windows.Forms.TabPage();
            this.knjigeTreeView = new System.Windows.Forms.TreeView();
            this.AnalizaTab = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bibliotekar.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clanoviDataGrid)).BeginInit();
            this.zaposleniciTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workersDataGrid)).BeginInit();
            this.knjigeTab.SuspendLayout();
            this.AnalizaTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Bibliotekar
            // 
            this.Bibliotekar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Bibliotekar.Controls.Add(this.tabPage2);
            this.Bibliotekar.Controls.Add(this.zaposleniciTab);
            this.Bibliotekar.Controls.Add(this.knjigeTab);
            this.Bibliotekar.Controls.Add(this.AnalizaTab);
            this.Bibliotekar.Location = new System.Drawing.Point(0, 31);
            this.Bibliotekar.Name = "Bibliotekar";
            this.Bibliotekar.SelectedIndex = 0;
            this.Bibliotekar.Size = new System.Drawing.Size(1052, 420);
            this.Bibliotekar.TabIndex = 0;
            this.Bibliotekar.Click += new System.EventHandler(this.Bibliotekar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.urediClanaButton);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.addClanButton);
            this.tabPage2.Controls.Add(this.clanoviDataGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1044, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Clanovi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // urediClanaButton
            // 
            this.urediClanaButton.Location = new System.Drawing.Point(570, 344);
            this.urediClanaButton.Name = "urediClanaButton";
            this.urediClanaButton.Size = new System.Drawing.Size(193, 41);
            this.urediClanaButton.TabIndex = 5;
            this.urediClanaButton.Text = "Uredi odabranog clana";
            this.urediClanaButton.UseVisualStyleBackColor = true;
            this.urediClanaButton.Click += new System.EventHandler(this.urediClanaButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(769, 343);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 42);
            this.button4.TabIndex = 4;
            this.button4.Text = "Brisi Clana";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(316, 343);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 45);
            this.button3.TabIndex = 3;
            this.button3.Text = "Pretraga";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 352);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(302, 22);
            this.textBox2.TabIndex = 2;
            // 
            // addClanButton
            // 
            this.addClanButton.Location = new System.Drawing.Point(895, 343);
            this.addClanButton.Name = "addClanButton";
            this.addClanButton.Size = new System.Drawing.Size(141, 42);
            this.addClanButton.TabIndex = 1;
            this.addClanButton.Text = "Dodaj Clana";
            this.addClanButton.UseVisualStyleBackColor = true;
            // 
            // clanoviDataGrid
            // 
            this.clanoviDataGrid.AllowUserToResizeRows = false;
            this.clanoviDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clanoviDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clanoviDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clanoviDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sifra,
            this.Ime,
            this.Prezime,
            this.EMail,
            this.Comment});
            this.clanoviDataGrid.Location = new System.Drawing.Point(0, 0);
            this.clanoviDataGrid.MultiSelect = false;
            this.clanoviDataGrid.Name = "clanoviDataGrid";
            this.clanoviDataGrid.ReadOnly = true;
            this.clanoviDataGrid.RowTemplate.Height = 24;
            this.clanoviDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clanoviDataGrid.Size = new System.Drawing.Size(1044, 337);
            this.clanoviDataGrid.TabIndex = 0;
            this.clanoviDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clanoviDataGrid_CellContentClick);
            // 
            // Sifra
            // 
            this.Sifra.HeaderText = "Sifra";
            this.Sifra.Name = "Sifra";
            this.Sifra.ReadOnly = true;
            // 
            // Ime
            // 
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // EMail
            // 
            this.EMail.HeaderText = "EMail";
            this.EMail.Name = "EMail";
            this.EMail.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // zaposleniciTab
            // 
            this.zaposleniciTab.Controls.Add(this.button2);
            this.zaposleniciTab.Controls.Add(this.textBox1);
            this.zaposleniciTab.Controls.Add(this.button1);
            this.zaposleniciTab.Controls.Add(this.workersDataGrid);
            this.zaposleniciTab.Controls.Add(this.dodajWorker);
            this.zaposleniciTab.Location = new System.Drawing.Point(4, 25);
            this.zaposleniciTab.Name = "zaposleniciTab";
            this.zaposleniciTab.Padding = new System.Windows.Forms.Padding(3);
            this.zaposleniciTab.Size = new System.Drawing.Size(1044, 391);
            this.zaposleniciTab.TabIndex = 2;
            this.zaposleniciTab.Text = "Zaposlenici";
            this.zaposleniciTab.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 47);
            this.button2.TabIndex = 6;
            this.button2.Text = "Pokreni";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 349);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(741, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Izbrisi randika";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // workersDataGrid
            // 
            this.workersDataGrid.AllowUserToResizeRows = false;
            this.workersDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workersDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.workersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Rola});
            this.workersDataGrid.Location = new System.Drawing.Point(0, 0);
            this.workersDataGrid.MultiSelect = false;
            this.workersDataGrid.Name = "workersDataGrid";
            this.workersDataGrid.ReadOnly = true;
            this.workersDataGrid.RowTemplate.Height = 24;
            this.workersDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.workersDataGrid.Size = new System.Drawing.Size(1044, 338);
            this.workersDataGrid.TabIndex = 3;
            this.workersDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.workersDataGrid_CellContentClick);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Ime";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Prezime";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "EMail";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // Rola
            // 
            this.Rola.HeaderText = "Rola";
            this.Rola.Name = "Rola";
            this.Rola.ReadOnly = true;
            // 
            // dodajWorker
            // 
            this.dodajWorker.Location = new System.Drawing.Point(897, 343);
            this.dodajWorker.Name = "dodajWorker";
            this.dodajWorker.Size = new System.Drawing.Size(141, 41);
            this.dodajWorker.TabIndex = 2;
            this.dodajWorker.Text = "Dodaj radnika";
            this.dodajWorker.UseVisualStyleBackColor = true;
            this.dodajWorker.Click += new System.EventHandler(this.dodajWorker_Click);
            // 
            // knjigeTab
            // 
            this.knjigeTab.Controls.Add(this.knjigeTreeView);
            this.knjigeTab.Location = new System.Drawing.Point(4, 25);
            this.knjigeTab.Name = "knjigeTab";
            this.knjigeTab.Padding = new System.Windows.Forms.Padding(3);
            this.knjigeTab.Size = new System.Drawing.Size(1044, 391);
            this.knjigeTab.TabIndex = 3;
            this.knjigeTab.Text = "Knjige";
            this.knjigeTab.UseVisualStyleBackColor = true;
            // 
            // knjigeTreeView
            // 
            this.knjigeTreeView.Location = new System.Drawing.Point(0, 0);
            this.knjigeTreeView.Name = "knjigeTreeView";
            this.knjigeTreeView.Size = new System.Drawing.Size(1044, 391);
            this.knjigeTreeView.TabIndex = 0;
            // 
            // AnalizaTab
            // 
            this.AnalizaTab.Controls.Add(this.pictureBox1);
            this.AnalizaTab.Location = new System.Drawing.Point(4, 25);
            this.AnalizaTab.Name = "AnalizaTab";
            this.AnalizaTab.Padding = new System.Windows.Forms.Padding(3);
            this.AnalizaTab.Size = new System.Drawing.Size(1044, 391);
            this.AnalizaTab.TabIndex = 4;
            this.AnalizaTab.Text = "Analiza";
            this.AnalizaTab.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1038, 385);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "EMail";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Prezime";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Ime";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Sifra";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 451);
            this.Controls.Add(this.Bibliotekar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminMainForm";
            this.Text = "AdminMainForm";
            this.Load += new System.EventHandler(this.AdminMainForm_Load);
            this.Bibliotekar.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clanoviDataGrid)).EndInit();
            this.zaposleniciTab.ResumeLayout(false);
            this.zaposleniciTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workersDataGrid)).EndInit();
            this.knjigeTab.ResumeLayout(false);
            this.AnalizaTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Bibliotekar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView clanoviDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.Button addClanButton;
        private System.Windows.Forms.TabPage zaposleniciTab;
        private System.Windows.Forms.Button dodajWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView workersDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rola;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button urediClanaButton;
        private System.Windows.Forms.TabPage knjigeTab;
        private System.Windows.Forms.TreeView knjigeTreeView;
        private System.Windows.Forms.TabPage AnalizaTab;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}