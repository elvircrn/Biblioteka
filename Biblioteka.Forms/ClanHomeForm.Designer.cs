namespace Biblioteka.Forms
{
    partial class ClanHomeForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.wishCheckList = new System.Windows.Forms.CheckedListBox();
            this.zaduzenjaGrid = new System.Windows.Forms.DataGridView();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naslov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zanr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RokVracanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knjigaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iKnjigaManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iBibliotekaManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.zaduzenjaGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knjigaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iKnjigaManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iBibliotekaManagerBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wishCheckList
            // 
            this.wishCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wishCheckList.FormattingEnabled = true;
            this.wishCheckList.Location = new System.Drawing.Point(752, 31);
            this.wishCheckList.Name = "wishCheckList";
            this.wishCheckList.Size = new System.Drawing.Size(265, 344);
            this.wishCheckList.TabIndex = 1;
            this.wishCheckList.SelectedIndexChanged += new System.EventHandler(this.wishCheckList_SelectedIndexChanged);
            // 
            // zaduzenjaGrid
            // 
            this.zaduzenjaGrid.AllowUserToResizeRows = false;
            this.zaduzenjaGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zaduzenjaGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.zaduzenjaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zaduzenjaGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sifra,
            this.Naslov,
            this.Autor,
            this.Zanr,
            this.RokVracanja});
            this.zaduzenjaGrid.Location = new System.Drawing.Point(12, 31);
            this.zaduzenjaGrid.Name = "zaduzenjaGrid";
            this.zaduzenjaGrid.ReadOnly = true;
            this.zaduzenjaGrid.RowTemplate.Height = 24;
            this.zaduzenjaGrid.Size = new System.Drawing.Size(733, 345);
            this.zaduzenjaGrid.TabIndex = 0;
            this.zaduzenjaGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Sifra
            // 
            this.Sifra.HeaderText = "Sifra";
            this.Sifra.Name = "Sifra";
            this.Sifra.ReadOnly = true;
            // 
            // Naslov
            // 
            this.Naslov.HeaderText = "Naslov";
            this.Naslov.Name = "Naslov";
            this.Naslov.ReadOnly = true;
            // 
            // Autor
            // 
            this.Autor.HeaderText = "Autor";
            this.Autor.Name = "Autor";
            this.Autor.ReadOnly = true;
            // 
            // Zanr
            // 
            this.Zanr.HeaderText = "Zanr";
            this.Zanr.Name = "Zanr";
            this.Zanr.ReadOnly = true;
            // 
            // RokVracanja
            // 
            dataGridViewCellStyle11.Format = "d";
            dataGridViewCellStyle11.NullValue = null;
            this.RokVracanja.DefaultCellStyle = dataGridViewCellStyle11;
            this.RokVracanja.HeaderText = "Rok Vracanja";
            this.RokVracanja.Name = "RokVracanja";
            this.RokVracanja.ReadOnly = true;
            // 
            // knjigaBindingSource
            // 
            this.knjigaBindingSource.DataSource = typeof(Biblioteka.Model.Knjiga);
            // 
            // iKnjigaManagerBindingSource
            // 
            this.iKnjigaManagerBindingSource.DataSource = typeof(Biblioteka.BLL.Interfaces.IKnjigaManager);
            // 
            // iBibliotekaManagerBindingSource
            // 
            this.iBibliotekaManagerBindingSource.DataSource = typeof(Biblioteka.BLL.Interfaces.IBibliotekaManager);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista zaduzenja";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(775, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lista zelja (right click za dodavanje)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1029, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewProfileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem1,
            this.exitToolStripMenuItem2});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.exitToolStripMenuItem.Text = "Actions";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem1.Text = "Log Out";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem2.Text = "Exit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // viewProfileToolStripMenuItem
            // 
            this.viewProfileToolStripMenuItem.Name = "viewProfileToolStripMenuItem";
            this.viewProfileToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.viewProfileToolStripMenuItem.Text = "View Profile";
            // 
            // ClanHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 448);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wishCheckList);
            this.Controls.Add(this.zaduzenjaGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClanHomeForm";
            this.Text = "ClanHomeForm";
            this.Load += new System.EventHandler(this.ClanHomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zaduzenjaGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knjigaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iKnjigaManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iBibliotekaManagerBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource iKnjigaManagerBindingSource;
        private System.Windows.Forms.BindingSource knjigaBindingSource;
        private System.Windows.Forms.BindingSource iBibliotekaManagerBindingSource;
        private System.Windows.Forms.CheckedListBox wishCheckList;
        private System.Windows.Forms.DataGridView zaduzenjaGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naslov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Autor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zanr;
        private System.Windows.Forms.DataGridViewTextBoxColumn RokVracanja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem viewProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}