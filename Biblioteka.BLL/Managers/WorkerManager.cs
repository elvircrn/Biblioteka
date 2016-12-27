using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Users;
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

        public static WorkerManager Seed(IUserManager userManager, IRoleManager roleManager)
        {
            WorkerManager workerManager = new WorkerManager();
            Worker admin = new Worker
            {
                Ime = "admin",
                Prezime = "admin",
                DatumRodjenja = new DateTime(1996, 7, 1),
                MaticniBroj = "123456789123",
                UserName = "admin",
                PasswordHash = Hash.Encode("admin"),
                Salary = 9999999,
                Occupation = "admin",
                WorkerID = "100",
                ProfileImage = new System.Drawing.Bitmap(200, 200), // Consider not doing this here
                Roles = new List<IRole>() { roleManager.GetRoleByName("ADMIN") }
            };

            workerManager.AddWorker(admin); // admin koji se koristi za testiranje
            userManager.AddUser((User)admin);

            for (int i = 0; i < 10; i++)
            {
                Worker worker = new Worker
                {
                    Ime = "BibliotekarIme" + i.ToString(),
                    Prezime = "BibliotekarPrezime" + i.ToString(),
                    DatumRodjenja = new DateTime(1996, 7, 1),
                    MaticniBroj = "123456789123" + i.ToString(),
                    UserName = "bibliotekar" + i.ToString(),
                    PasswordHash = Hash.Encode("aaa"),
                    WorkerID = i.ToString(),
                    Occupation = "Bibliotekar",
                    Salary = NumberGenerator.GetRandomNumber(1000),
                    ProfileImage = new System.Drawing.Bitmap(200, 200), // Consider not doing this here
                    Roles = new List<IRole>() { roleManager.GetRoleByName("WORKER") }
                };
                workerManager.AddWorker(worker);
                userManager.AddUser((User)worker);
            }

            for (int i = 10; i < 20; i++)
            {
                Worker worker = new Worker
                {
                    Ime = "DomarIme" + i.ToString(),
                    Prezime = "DomarPrezime" + i.ToString(),
                    DatumRodjenja = new DateTime(1996, 7, i),
                    MaticniBroj = "123456789123" + i.ToString(),
                    UserName = "worker" + i.ToString(),
                    PasswordHash = "", // Domari nemaju pristupne podatke sistemu
                    WorkerID = i.ToString(),
                    Occupation = "Domar",
                    Salary = NumberGenerator.GetRandomNumber(1000),
                    ProfileImage = new System.Drawing.Bitmap(200, 200), // Consider not doing this here
                    Roles = new List<IRole>()
                };
                workerManager.AddWorker(worker);
                userManager.AddUser((User)worker);
            }

            return workerManager;
        }
    }
}
