using Biblioteka.BLL.Managers;
using Biblioteka.Common;
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
    public partial class LogInForm : Form
    {
        private DataAPI data;

        public LogInForm()
        {
            InitializeComponent();
        }

        public LogInForm(DataAPI dataAPI) : this()
        {
            this.data = dataAPI;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            data.SessionAPI.CurrentUser = data.UserAPI.LogIn(usernameTextBox.Text, passwordTextBox.Text);

            if (data.SessionAPI.CurrentUser == null)
            {
                MessageBox.Show("Username or password not valid");
                return;
            }

            if (data.SessionAPI.CurrentUser.IsInRole(RoleManager.CLAN))
            {
                ClanHomeForm clForm = new ClanHomeForm(data);
                clForm.Show();
                clForm.Activate();
                clForm.BringToFront();
                clForm.FormClosed += delegate { this.Show(); };
                this.Hide();
            }
            else if (data.SessionAPI.CurrentUser.IsInRole(RoleManager.ADMIN))
            {
                AdminMainForm adminForm = new AdminMainForm(data);
                adminForm.Show();
                adminForm.Activate();
                adminForm.BringToFront();
                adminForm.FormClosed += delegate { this.Show(); };
                this.Hide();
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
        }
    }
}
