using Biblioteka;
using Biblioteka.BLL.Managers;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.BLL.Interfaces;
using Biblioteka.BLL;
using Biblioteka.BLL.Managers.Interfaces;
using Biblioteka.DAL;

namespace Biblioteka.Forms
{
    /*
     * 
     */
    public class DataAPI
    {
        public IUserManager UserAPI { get; set; }

        public IWorkerManager WorkerAPI { get; set; }

        public IClanManager ClanAPI { get; set; }

        public IRoleManager RoleAPI { get; set; }

        public IBibliotekaManager BibliotekaAPI { get; set; }

        public IKnjigaManager KnjigaAPI { get; set; }

        public ISessionService SessionAPI { get; set; }

        public static DataAPI Inject(ApplicationDbContext context)
        {
            DataAPI dataAPI = new DataAPI();

            dataAPI.UserAPI = new UserManager(context);
            dataAPI.ClanAPI = new ClanManager(context);
            dataAPI.RoleAPI = new RoleManager(context);
            dataAPI.KnjigaAPI = new KnjigaManager(context);
            dataAPI.SessionAPI = new SessionService();
            dataAPI.WorkerAPI = new WorkerManager(context);
            dataAPI.BibliotekaAPI = new BibliotekaManager("Dobrinja", dataAPI.ClanAPI, dataAPI.KnjigaAPI, 123.0);

            return dataAPI;
        }
    }
}
