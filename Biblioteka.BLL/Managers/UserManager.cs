using Biblioteka.BLL.Interfaces;
using Biblioteka.Common.Security;
using Biblioteka.Model;
using Biblioteka.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private List<User> _users;

        public User CurrentUser { get; set; }

        public UserManager()
        {
            _users = new List<User>();
        }

        public User LogIn(string username, string password)
        {
            string hash = Hash.Encode(password);

            foreach (User user in _users)
                if (user.UserName == username && user.PasswordHash == hash)
                    return user;

            return null;
        }

        public User AddUser(User user)
        {
            _users.Add(user);
            return user;
        }

        public static UserManager Seed(IRoleManager roleManager)
        {
            UserManager userManager = new UserManager();

            userManager.AddUser(new User
            {
                Ime = "admin",
                Prezime = "admin",
                DatumRodjenja = new DateTime(1996, 7, 2),
                MaticniBroj = "123456789123",
                UserName = "admin",
                PasswordHash = Hash.Encode("admin"),
                Roles = new List<IRole>() { roleManager.GetRoleByName("ADMIN") },
            });

            return userManager;
        }

    }
}
