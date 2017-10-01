using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Gradebook.DataAccessLayer.Models;
using System.Data;

namespace Gradebook.DataAccessLayer.DBAccess
{
    public class Roles
    {
        private readonly SqlConnection connection;

        internal Roles(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

        public IEnumerable<Role> GetAll()
        {
            using (SqlCommand command = new SqlCommand("EXEC RoleGetAll", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Role> roles = new List<Role>();
                    while (reader.Read())
                        roles.Add(CreateRole(reader));

                    return roles;
                }
            }
        }

        public Role GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC RoleGetById @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateRole(reader);

                    return null;
                }

            }
        }

        public IEnumerable<Role> GetAllByUserId(User user)
        {
            using (SqlCommand command = new SqlCommand("EXEC RoleGetAllByUserId @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Role> roles = new List<Role>();
                    while (reader.Read())
                        roles.Add(CreateRole(reader));

                    return roles;
                }
            }
        }

        public int Insert(Role role)
        {
            if (role == null)
                throw new ArgumentException("role", "Valid role is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC RoleInsert @Name", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = role.Name;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("role", "Valid role is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC RoleUpdate @Id, @Name", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = role.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = role.Name;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("role", "Valid role is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC RoleDelete @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = role.Id;

                command.ExecuteNonQuery();
            }
        }

        private Role CreateRole(IDataReader reader)
        {
            return new Role((int)reader["Id"], reader["Name"] as string);
        }
    }
}
