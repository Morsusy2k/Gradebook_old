using Gradebook.DataAccessLayer.Models;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Providers
{
    public interface IRoleProvider
    {
        Role GetRoleById(int id);
        List<Role> GetAllRoles();

        void InsertRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
    }
}
