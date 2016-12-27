using Biblioteka.BLL.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Users;

namespace Biblioteka.BLL.Managers
{
    public class SessionService : ISessionService
    {
        public IClan CurrentClan
        {
            get { return CurrentUser as IClan; }
        }

        public User CurrentUser { get; set; }

        public IWorker CurrentWorker
        {
            get { return CurrentUser as IWorker; }
        }
    }
}
