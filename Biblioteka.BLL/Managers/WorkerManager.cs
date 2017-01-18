using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Common.Security;
using Biblioteka.Model;
using Biblioteka.BLL.Interfaces;
using Biblioteka.DAL;
using System.Collections.Concurrent;

namespace Biblioteka.BLL.Managers
{
    public class WorkerManager : IWorkerManager
    {
        private List<IWorker> workersCache;
        ApplicationDbContext _context;

        private List<IWorker> _workers
        {
            get
            {
                if (workersCache == null)
                    workersCache = _context.Workers.ToList().Select(x => (IWorker)x).ToList();
                return workersCache;
            }
        }


        // OK
        public WorkerManager(ApplicationDbContext context)
        {
            _context = context;
        }

        // OK
        public IWorker AddWorker(IWorker worker)
        {
            var query = _context.Workers.Where(x => x.WorkerId == worker.WorkerId).FirstOrDefault();
            if (query == null)
            {
                _workers.Add(worker);
                _context.Workers.Add((Worker)worker);
                _context.SaveChanges();
            }
            
            return worker;
        }

        // OK
        public List<IWorker> GetWorkers()
        {
            return _workers;
        }

        // OK
        public void RemoveWorker(string workerId)
        {
            var worker = _context.Workers.Where(x => x.WorkerId == workerId).FirstOrDefault();

            if (worker != null)
            {
                _context.Workers.Remove(worker);
                _context.SaveChanges();
            }

            _workers.Remove(_workers.Where(x => x.WorkerId == workerId).FirstOrDefault());
        }

        // OK
        public List<IWorker> GetWorkers(string keywords)
        {
            if (keywords == "")
                return GetWorkers();
            else
                return _workers.Where(x => x.ToString().Contains(keywords)).ToList();
        }

        public void AddWorkerRange(List<Worker> list)
        {
            int ind = 0;
            var cd = new ConcurrentDictionary<int, Worker>(list
                .Select(x => new KeyValuePair<int, Worker>(ind++, x))
                .ToList());

            Parallel.ForEach(cd, x =>
            {
                AddWorker(x.Value);
            });
        }
    }
}
