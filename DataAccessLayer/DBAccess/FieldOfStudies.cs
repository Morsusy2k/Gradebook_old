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
    public class FieldOfStudies
    {
        private readonly SqlConnection connection;

        internal FieldOfStudies(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

        public IEnumerable<FieldOfStudy> GetAll()
        {
            using (SqlCommand command = new SqlCommand("EXEC FieldOfStudyGetAll", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<FieldOfStudy> fieldOfStudies = new List<FieldOfStudy>();
                    while (reader.Read())
                        fieldOfStudies.Add(CreateFieldOfStudy(reader));

                    return fieldOfStudies;
                }
            }
        }

        public FieldOfStudy GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC FieldOfStudyGetById @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateFieldOfStudy(reader);

                    return null;
                }

            }
        }

        public int Insert(FieldOfStudy fieldOfStudy)
        {
            if (fieldOfStudy == null)
                throw new ArgumentException("fieldOfStudy", "Valid fieldOfStudy is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC FieldOfStudyInsert @Name", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = fieldOfStudy.Name;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(FieldOfStudy fieldOfStudy)
        {
            if (fieldOfStudy == null)
                throw new ArgumentNullException("fieldOfStudy", "Valid fieldOfStudy is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC FieldOfStudyUpdate @Id, @Name", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = fieldOfStudy.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = fieldOfStudy.Name;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(FieldOfStudy fieldOfStudy)
        {
            if (fieldOfStudy == null)
                throw new ArgumentNullException("fieldOfStudy", "Valid fieldOfStudy is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC FieldOfStudyDelete @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = fieldOfStudy.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = fieldOfStudy.Name;

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<FieldOfStudyHasSubjects> GetAllSubjectsByFieldOfStudyId(FieldOfStudies fieldOfStudies)
        {
            using (SqlCommand command = new SqlCommand("EXEC FieldOfStudyGetSubjectsById @fieldOfStudyId", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<FieldOfStudyHasSubjects> fields = new List<FieldOfStudyHasSubjects>();
                    while (reader.Read())
                        fields.Add(CreateFieldOfStudyHasSubjects(reader));

                    return fields;
                }
            }
        }

        public int InsertSubject(FieldOfStudy fieldOfStudy, Subject subject)
        {
            if (fieldOfStudy == null)
                throw new ArgumentException("fieldOfStudy", "Valid field of study is mandatory!");

            if (subject == null)
                throw new ArgumentException("subject", "Valid subject is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC FieldOfStudyInsertSubject @fieldOfStudyId, @subjectId", connection))
            {
                command.Parameters.Add("@fieldOfStudyId", SqlDbType.Int).Value = fieldOfStudy.Id;
                command.Parameters.Add("@subjectId", SqlDbType.Int).Value = subject.Id;

                return (int)command.ExecuteScalar();
            }
        }

        public void DeleteSubject(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC FieldOfStudyDeleteSubject @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
        }

        private FieldOfStudy CreateFieldOfStudy(IDataReader reader)
        {
            return new FieldOfStudy((int)reader["Id"], reader["Name"] as string);
        }

        private FieldOfStudyHasSubjects CreateFieldOfStudyHasSubjects(IDataReader reader)
        {
            return new FieldOfStudyHasSubjects((int)reader["Id"], (int)reader["FieldOfStudyId"], (int)reader["SubjectId"]);
        }
    }
}
