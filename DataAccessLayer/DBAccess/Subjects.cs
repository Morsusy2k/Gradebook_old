using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.DataAccessLayer.Models;
using System.Data;

namespace Gradebook.DataAccessLayer.DBAccess
{
    public class Subjects
    {
        private readonly SqlConnection connection;

        internal Subjects(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

        public IEnumerable<Subject> GetAll()
        {
            using (SqlCommand command = new SqlCommand("EXEC SubjectGetAll", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Subject> subjects = new List<Subject>();
                    while (reader.Read())
                        subjects.Add(CreateSubject(reader));

                    return subjects;
                }
            }
        }

        public Subject GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC SubjectGetById @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateSubject(reader);

                    return null;
                }
            }
        }

        public IEnumerable<Subject> GetAllByUserId(User user)
        {
            using (SqlCommand command = new SqlCommand("EXEC SubjectGetAllByUserId @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Subject> subjects = new List<Subject>();
                    while (reader.Read())
                        subjects.Add(CreateSubject(reader));

                    return subjects;
                }
            }
        }

        public int Insert(Subject subject)
        {
            if (subject == null)
                throw new ArgumentNullException("subject", "Valid subject is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC SubjectInsert @userId, @name", connection))
            {
                command.Parameters.Add("@userId", SqlDbType.Int).Value = subject.UserId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = subject.Name;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(Subject subject)
        {
            if (subject == null)
                throw new ArgumentNullException("subject", "Valid subject is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC SubjectUpdate @Id, @userId, @name", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = subject.Id;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = subject.UserId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = subject.Name;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Subject subject)
        {
            if (subject == null)
                throw new ArgumentNullException("subject", "Valid subject is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC SubjectDelete @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = subject.Id;

                command.ExecuteNonQuery();
            }
        }

        private Subject CreateSubject(IDataReader reader)
        {
            return new Subject((int)reader["Id"], (int)reader["userId"], reader["name"] as string);
        }
    }
}
