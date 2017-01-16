using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Common.Security;
using Biblioteka.Model;
using Biblioteka.BLL.Interfaces;

namespace Biblioteka.BLL.Managers
{
    public class WorkerManager : IWorkerManager
    {
        private List<IWorker> _workers;

        public WorkerManager()
        {
            _workers = new List<IWorker>();
        }

        public IWorker AddWorker(IWorker worker)
        {
            _workers.Add(worker);
            return worker;
        }


        public List<IWorker> GetWorkers()
        {
            return _workers;
        }

        public void RemoveWorker(string workerId)
        {
            _workers.Remove(_workers.Where(x => x.WorkerID == workerId).FirstOrDefault());
        }

        public List<IWorker> GetWorkers(string keywords)
        {
            if (keywords == "")
                return GetWorkers();
            else
                return _workers.Where(x => x.ToString().Contains(keywords)).ToList();
        }
    }
}
