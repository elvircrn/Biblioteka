using Biblioteka.BLL.Interfaces;
using Biblioteka.DAL;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.BLL.Managers
{
    public sealed class RoleManager : IRoleManager
    {
        private ApplicationDbContext _context;
        private List<IRole> rolesCache;

        private List<IRole> Roles
        {
            get
            {
                if (rolesCache == null)
                    rolesCache = _context.Roles.ToList().Select(x => (IRole)x).ToList();
                return rolesCache;
            }
        }

        public static string ADMIN { get { return "ADMIN"; } }

        public static string WORKER { get { return "WORKER"; } }

        public static string CLAN { get { return "CLAN"; } }

        public RoleManager(ApplicationDbContext context)
        {
            context = _context;
        }

        public void AddRole(Model.IRole role)
        {
            Roles.Add(role);
        }

        public IRole GetRoleByName(string name)
        {
            IRole role = Roles.Where(x => x.Name == name).FirstOrDefault();
            if (role == null)
                throw new Exception("Role not found");
            else
                return role;
        }
    }
}
