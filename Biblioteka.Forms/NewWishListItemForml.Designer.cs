using System.Windows.Forms;

namespace Biblioteka.Forms
{
    partial class NewWishListItemForm : Form
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.searchText = new System.Windows.Forms.TextBox();
            this.pretragaButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.knjigeSearchResult = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GodinaIzdanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.knjigeSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Keywords";
            // 
            // searchText
            // 
            this.searchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchText.Location = new System.Drawing.Point(82, 8);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(293, 22);
            this.searchText.TabIndex = 1;
            // 
            // pretragaButton
            // 
            this.pretragaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pretragaButton.Location = new System.Drawing.Point(381, 7);
            this.pretragaButton.Name = "pretragaButton";
            this.pretragaButton.Size = new System.Drawing.Size(87, 23);
            this.pretragaButton.TabIndex = 3;
            this.pretragaButton.Text = "Pretraga";
            this.pretragaButton.UseVisualStyleBackColor = true;
            this.pretragaButton.Click += new System.EventHandler(this.pretragaButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectButton.Location = new System.Drawing.Point(347, 286);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(121, 31);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // knjigeSearchResult
            // 
            this.knjigeSearchResult.AllowUserToAddRows = false;
            this.knjigeSearchResult.AllowUserToDeleteRows = false;
            this.knjigeSearchResult.AllowUserToResizeRows = false;
            this.knjigeSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knjigeSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.knjigeSearchResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Autor,
            this.GodinaIzdanja});
            this.knjigeSearchResult.Location = new System.Drawing.Point(10, 38);
            this.knjigeSearchResult.Name = "knjigeSearchResult";
            this.knjigeSearchResult.RowTemplate.Height = 24;
            this.knjigeSearchResult.Size = new System.Drawing.Size(457, 237);
            this.knjigeSearchResult.TabIndex = 5;
            // 
            // Naziv
            // 
            this.Naziv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            // 
            // Autor
            // 
            this.Autor.HeaderText = "Autor";
            this.Autor.Name = "Autor";
            // 
            // GodinaIzdanja
            // 
            this.GodinaIzdanja.HeaderText = "Godina Izdanja";
            this.GodinaIzdanja.Name = "GodinaIzdanja";
            // 
            // NewWishListItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 318);
            this.Controls.Add(this.knjigeSearchResult);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.pretragaButton);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.label1);
            this.Name = "NewWishListItemForm";
            this.Load += new System.EventHandler(this.NewWishListItemControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.knjigeSearchResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Button pretragaButton;
        private System.Windows.Forms.Button selectButton;
        private DataGridView knjigeSearchResult;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewTextBoxColumn Autor;
        private DataGridViewTextBoxColumn GodinaIzdanja;
    }
}
