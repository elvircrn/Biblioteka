﻿using Biblioteka.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.BLL.Interfaces
{
    public interface IWorkerManager
    {
        IWorker AddWorker(IWorker worker);
    }
}
