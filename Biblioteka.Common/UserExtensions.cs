using Biblioteka.Common.Identity;
using Biblioteka.Model;
using Biblioteka.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Common
{
    public static class UserExtensions
    {
        public static bool IsInRole(this User user, string name)
        {
            return user.Roles.Where(x => x.Name == name).FirstOrDefault() != null;
        }
    }
}
