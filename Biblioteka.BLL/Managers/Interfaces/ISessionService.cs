using Biblioteka.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.BLL.Managers.Interfaces
{
    public interface ISessionService
    {
        User CurrentUser { get; set; }

        IClan CurrentClan { get; }

        IWorker CurrentWorker { get; }
    }
}
