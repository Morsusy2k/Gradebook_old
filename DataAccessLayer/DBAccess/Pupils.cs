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
    public class Pupils
    {
        private readonly SqlConnection connection;

        internal Pupils(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

        public IEnumerable<Pupil> GetAll()
        {
            using (SqlCommand command = new SqlCommand("EXEC PupilGetAll", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Pupil> pupils = new List<Pupil>();
                    while (reader.Read())
                        pupils.Add(CreatePupil(reader));

                    return pupils;
                }
            }
        }

        public Pupil GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC PupilGetById @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreatePupil(reader);

                    return null;
                }

            }
        }

        public int Insert(Pupil pupil)
        {
            if (pupil == null)
                throw new ArgumentException("pupil", "Valid pupil is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC PupilInsert @pClassId, @Name", connection))
            {
                command.Parameters.Add("@pClassId", SqlDbType.Int).Value = pupil.PClassId;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = pupil.Name;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(Pupil pupil)
        {
            if (pupil == null)
                throw new ArgumentNullException("pupil", "Valid pupil is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC PupilUpdate @Id, @PClassId, @Name", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = pupil.Id;
                command.Parameters.Add("@pClassId", SqlDbType.Int).Value = pupil.PClassId;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = pupil.Name;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Pupil pupil)
        {
            if (pupil == null)
                throw new ArgumentNullException("pupil", "Valid pupil is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC PupilDelete @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = pupil.Id;

                command.ExecuteNonQuery();
            }
        }

        private Pupil CreatePupil(IDataReader reader)
        {
            return new Pupil((int)reader["Id"], (int)reader["PClassId"], reader["Name"] as string);
        }
    }
}
