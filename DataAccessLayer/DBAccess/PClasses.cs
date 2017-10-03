using Gradebook.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.DataAccessLayer.DBAccess
{
    public class PClasses
    {
        private readonly SqlConnection connection;

        internal PClasses(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

        public IEnumerable<PClass> GetAll()
        {
            using (SqlCommand command = new SqlCommand("EXEC PClassGetAll", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<PClass> pClasses = new List<PClass>();
                    while (reader.Read())
                        pClasses.Add(CreatePClass(reader));

                    return pClasses;
                }
            }
        }

        public PClass GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC PClassGetById @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreatePClass(reader);

                    return null;
                }
            }
        }

        public IEnumerable<PClass> GetAllByUserId(User user)
        {
            using (SqlCommand command = new SqlCommand("EXEC PClassGetAllByUserId @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<PClass> pclasses = new List<PClass>();
                    while (reader.Read())
                        pclasses.Add(CreatePClass(reader));

                    return pclasses;
                }
            }
        }

        public IEnumerable<PClass> GetAllByYear(string year)
        {
            using (SqlCommand command = new SqlCommand("EXEC PClassGetByYear @Id", connection))
            {
                command.Parameters.Add("@Year", SqlDbType.NVarChar).Value = year;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<PClass> pclasses = new List<PClass>();
                    while (reader.Read())
                        pclasses.Add(CreatePClass(reader));

                    return pclasses;
                }
            }
        }

        public int Insert(PClass pClass)
        {
            if (pClass == null)
                throw new ArgumentNullException("pClass", "Valid pClass is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC PClassInsert @userId, @fieldOfStudyId, @generation, @Year, @PClassIndex", connection))
            {
                command.Parameters.Add("@userId", SqlDbType.Int).Value = pClass.UserId;
                command.Parameters.Add("@fieldOfStudyId", SqlDbType.Int).Value = pClass.FieldOfStudyId;
                command.Parameters.Add("@generation", SqlDbType.DateTime).Value = pClass.Generation;
                command.Parameters.Add("@Year", SqlDbType.NVarChar).Value = pClass.Year;
                command.Parameters.Add("@PClassIndex", SqlDbType.Int).Value = pClass.PClassIndex;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(PClass pClass)
        {
            if (pClass == null)
                throw new ArgumentNullException("pClass", "Valid pClass is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC PClassUpdate @Id, @userId, @fieldOfStudyId, @generation, @Year, @PClassIndex", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = pClass.Id;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = pClass.UserId;
                command.Parameters.Add("@fieldOfStudyId", SqlDbType.Int).Value = pClass.FieldOfStudyId;
                command.Parameters.Add("@generation", SqlDbType.DateTime).Value = pClass.Generation;
                command.Parameters.Add("@Year", SqlDbType.NVarChar).Value = pClass.Year;
                command.Parameters.Add("@PClassIndex", SqlDbType.Int).Value = pClass.PClassIndex;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(PClass pClass)
        {
            if (pClass == null)
                throw new ArgumentNullException("pClass", "Valid pClass is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC PClassDelete @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = pClass.Id;

                command.ExecuteNonQuery();
            }
        }

        private PClass CreatePClass(IDataReader reader)
        {
            return new PClass((int)reader["Id"], (int)reader["UserId"], (int)reader["FieldOfStudyId"], (DateTime)reader["Generation"], reader["Year"] as string, (int)reader["PClassIndex"]);
        }
    }
}
