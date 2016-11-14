using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public sealed class RoleManager<Role> where Role : IRole
    {
        private List<Role> Roles;

        public RoleManager()
        {
            Roles = new List<Role>();
        }

        public void AddRole(Role role)
        {
            Roles.Add(role);
        }

        public Role GetRoleByName(string name)
        {
            var role = Roles.Where(x => x.Name == name).FirstOrDefault();
            if (role == null)
                throw new Exception("Role not found");
            else
                return role;
        }
    }
}
