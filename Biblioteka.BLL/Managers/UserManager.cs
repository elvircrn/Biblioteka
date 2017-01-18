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

        // OK
        private List<User> _users
        {
            get
            {
                if (_usersCache == null)
                    _usersCache = _context.Users.Include("Roles").ToList();
                return _usersCache;
            }
        }

        // OK
        public User CurrentUser { get; set; }

        // OK
        public UserManager(ApplicationDbContext context)
        {
            _context = context;
        }

        // OK
        public User LogIn(string username, string password)
        {
            string hash = Hash.Encode(password);

            foreach (User user in _users)
                if (user.UserName == username && user.PasswordHash == hash)
                    return user;

            return null;
        }

        // OK
        public User AddUser(User user)
        {
            // Does this user already exist?
            var query = _context.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();

            if (query == null)
                return user;
            else
            {
                _context.Users.Add(user);
                _usersCache.Add(user);
                _context.SaveChanges();
            }

            return user;
        }

        // OK
        public bool UsernameTaken(string username)
        {
            // Query the database to check if the username already exists
            var query = _context.Users.Where(x => x.UserName == username).FirstOrDefault();
            return (query != null) ;
        }
    }
}
