namespace Biblioteka.Forms
{
    partial class Test
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
            this.userControl11 = new Biblioteka.Forms.UserControl1();
            this.userControl12 = new Biblioteka.Forms.UserControl1();
            this.imagePicker1 = new Biblioteka.Forms.ImagePicker();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(32, 134);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(150, 150);
            this.userControl11.TabIndex = 0;
            // 
            // userControl12
            // 
            this.userControl12.Location = new System.Drawing.Point(13, 76);
            this.userControl12.Name = "userControl12";
            this.userControl12.Size = new System.Drawing.Size(150, 150);
            this.userControl12.TabIndex = 1;
            // 
            // imagePicker1
            // 
            this.imagePicker1.Location = new System.Drawing.Point(32, 18);
            this.imagePicker1.Name = "imagePicker1";
            this.imagePicker1.Size = new System.Drawing.Size(280, 266);
            this.imagePicker1.TabIndex = 2;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 359);
            this.Controls.Add(this.imagePicker1);
            this.Controls.Add(this.userControl12);
            this.Controls.Add(this.userControl11);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl1 userControl11;
        private UserControl1 userControl12;
        private ImagePicker imagePicker1;
    }
}