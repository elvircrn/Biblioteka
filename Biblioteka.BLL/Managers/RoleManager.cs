using Biblioteka.BLL.Interfaces;
using Biblioteka.Common.Identity;
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
        private List<IRole> Roles;

        public static string ADMIN { get { return "ADMIN"; } }

        public static string WORKER { get { return "WORKER"; } }

        public static string CLAN { get { return "CLAN"; } }

        public RoleManager()
        {
            Roles = new List<IRole>();
        }

        public void AddRole(IRole role)
        {
            Roles.Add(role);
        }

        public IRole GetRoleByName(string name)
        {
            var role = Roles.Where(x => x.Name == name).FirstOrDefault();
            if (role == null)
                throw new Exception("Role not found");
            else
                return role;
        }

        public static RoleManager Seed()
        {
            RoleManager roleManager = new RoleManager();

            roleManager.AddRole(new Role("ADMIN", "Admin"));
            roleManager.AddRole(new Role("WORKER", "Bibliotekar"));
            roleManager.AddRole(new Role("CLAN", "Clan"));
            roleManager.AddRole(new Role("TECH", "Tehnicar"));

            return roleManager;
        }
    }
}
