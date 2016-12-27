using Biblioteka;
using Biblioteka.BLL.Managers;
using Biblioteka.Common.Identity;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Users;
using Biblioteka.BLL.Interfaces;
using Biblioteka.BLL;
using Biblioteka.BLL.Managers.Interfaces;

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

        public static DataAPI Seed()
        {
            DataAPI dataAPI = new DataAPI();

            dataAPI.RoleAPI = RoleManager.Seed();

            dataAPI.UserAPI = UserManager.Seed(dataAPI.RoleAPI);

            dataAPI.ClanAPI = ClanManager.Seed(dataAPI.UserAPI, dataAPI.RoleAPI);

            dataAPI.WorkerAPI = WorkerManager.Seed(dataAPI.UserAPI, dataAPI.RoleAPI);

            dataAPI.KnjigaAPI = KnjigaManager.Seed();

            dataAPI.BibliotekaAPI = BibliotekaManager.Seed(dataAPI.ClanAPI, dataAPI.KnjigaAPI);

            dataAPI.SessionAPI = new SessionService();

            return dataAPI;
        }
    }
}
