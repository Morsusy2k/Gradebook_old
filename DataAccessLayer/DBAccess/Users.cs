using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Gradebook.DataAccessLayer.Models;
using System.Data;

namespace Gradebook.DataAccessLayer.DBAccess
{
    public class Users
    {
        private readonly SqlConnection connection;

        internal Users(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory");
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlCommand command = new SqlCommand("EXEC UserGetAll", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<User> users = new List<User>();
                    while (reader.Read())
                        users.Add(CreateUser(reader));

                    return users;
                }
            }
        }

        public User GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC UserGetById @Id", connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateUser(reader);

                    return null;
                }
            }
        }

        public int Insert(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user", "Valid user is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC UserInsert @Name, @Surname, @Username, @Password, @Email", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = user.Name;
                command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = user.Surname;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.Password;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user", "Valid user is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC UserUpdate @Id, @Name, @Surname, @Username, @Password, @Email", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = user.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = user.Name;
                command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = user.Surname;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.Password;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user", "Valid user is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC UserDelete @Id ", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
                command.ExecuteNonQuery();
            }
        }

        private IEnumerable<UserRole> GetRolesByUserId(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user", "Valid user is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC UserRolesGetByUserId @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<UserRole> userRoles = new List<UserRole>();
                    while (reader.Read())
                        userRoles.Add(CreateUserRole(reader));

                    return userRoles;
                }
            }
        }

        public int InsertUserRole(User user, Role role)
        {
            if (user == null)
                throw new ArgumentNullException("user", "Valid user is mandatory!");

            if (role == null)
                throw new ArgumentNullException("role", "Valid role is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC UserRoleInsert @UserId, @RoleId", connection))
            {
                command.Parameters.Add("@UserId", SqlDbType.Int).Value = user.Id;
                command.Parameters.Add("@RoleId", SqlDbType.Int).Value = role.Id;

                return (int)command.ExecuteScalar();
            }
        }

        public void DeleteUserRole(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC UserRoleDelete @Id ", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        private User CreateUser(IDataReader reader)
        {
            return new User((int)reader["Id"], reader["Name"] as string, reader["Surname"] as string, reader["Username"] as string, reader["Password"] as string, reader["Email"] as string);
        }

        private UserRole CreateUserRole(IDataReader reader)
        {
            return new UserRole((int)reader["Id"], (int)reader["UserId"], (int)reader["RoleId"]);
        }
    }
}
