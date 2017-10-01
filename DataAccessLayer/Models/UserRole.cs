using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.DataAccessLayer.Models
{
    public class UserRole
    {
        public UserRole() { }
        public UserRole(int id, int userId, int roleId)
        {
            Id = id;
            UserId = userId;
            RoleId = roleId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
