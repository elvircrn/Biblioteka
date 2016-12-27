using Biblioteka.Model;

namespace Biblioteka.BLL.Interfaces
{
    public interface IRoleManager
    {
        void AddRole(IRole role);
        IRole GetRoleByName(string name);
    }
}