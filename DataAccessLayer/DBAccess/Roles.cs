using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Gradebook.DataAccessLayer.Models;
using System.Data;
using Gradebook.RepositoryLayer.Repositories;
using System.Configuration;

namespace Gradebook.DataAccessLayer.DBAccess
{
    public class Roles : IRoleRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionStringName].ConnectionString;

        private readonly SqlConnection connection;

        internal Roles(SqlConnection connection)
        {
            this.connection = new SqlConnection(_connectionString) ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
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

// SQL INSERT WITH OUTPUT PARAMETERS
//using (var sqlConnection = new SqlConnection(connectionString))
//                {
//                    sqlConnection.Open();
//                    using (SqlCommand sqlCommand = new SqlCommand("CompanyInsert", sqlConnection))
//                    {
//                        sqlCommand.CommandType = CommandType.StoredProcedure;

//                        sqlCommand.Parameters.AddWithValue("@CountryId", company.CountryId);
//                        sqlCommand.Parameters.AddWithValue("@Name", company.Name);
//                        sqlCommand.Parameters.AddWithValue("@City", company.City);
//                        sqlCommand.Parameters.AddWithValue("SendHoursAlerts", company.SendHoursAlerts);
//                        sqlCommand.Parameters.AddWithValue("@CreatedDate", company.CreatedDate);
//                        sqlCommand.Parameters.AddWithValue("@ModifiedDate", company.ModifiedDate);


//                        SqlParameter outputIdParam = new SqlParameter("@CompanyId", SqlDbType.Int);
//outputIdParam.Direction = ParameterDirection.Output;
//                        sqlCommand.Parameters.Add(outputIdParam);

//                        SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
//outputVersionParam.Direction = ParameterDirection.Output;
//                        sqlCommand.Parameters.Add(outputVersionParam);

//                        sqlCommand.ExecuteNonQuery();

//                        company.Id = Convert.ToInt32(outputIdParam.Value);
//                        company.Version = (byte[]) (outputVersionParam.Value);
//                    }
//                }