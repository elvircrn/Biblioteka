using Biblioteka.BLL.Interfaces;
using Biblioteka.Common.Security;
using Biblioteka.DAL;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private List<User> _usersCache;
        private ApplicationDbContext _context;

        private List<User> _users
        {
            get
            {
                if (_usersCache == null)
                    _usersCache = _context.Users.ToList();
                return _usersCache;
            }
        }

        public User CurrentUser { get; set; }

        public UserManager(ApplicationDbContext context)
        {
            _context = context;
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

        public bool UsernameTaken(string username)
        {
            return (_users.Where(x => x.UserName == username).FirstOrDefault() != null);
        }


    }
}
