using Biblioteka.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Application.Run(new LogInForm(DataAPI.Inject(context)));
            }
        }
    }
}
