using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public static class ClanManagerExtensions
    {
        public static void AddToRole<Role> (this ClanManager clanManager, Clan clan, RoleManager<Role> roleManager, string role) where Role : IRole
        {
            clan.Role = roleManager.GetRoleByName(role);
        }
    }
}
