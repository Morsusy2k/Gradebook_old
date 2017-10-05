using Gradebook.DataAccessLayer.Models;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Repositories
{
    public interface IRoleRepository
    {
        Role GetRoleById(int id);
        List<Role> GetAllRoles(); //IEnumberable?

        void InsertRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
    }
}
