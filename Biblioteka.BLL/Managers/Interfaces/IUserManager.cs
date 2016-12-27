using Biblioteka.Users;

namespace Biblioteka.BLL.Interfaces
{
    public interface IUserManager
    {
        User LogIn(string username, string password);

        User AddUser(User user);

        User CurrentUser { get; set; }

        bool UsernameTaken(string username);
    }
}