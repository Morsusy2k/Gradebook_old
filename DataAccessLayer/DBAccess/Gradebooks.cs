using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.DataAccessLayer.Models;

namespace Gradebook.DataAccessLayer.DBAccess
{
    public class Gradebooks
    {
        private readonly SqlConnection connection;

        internal Gradebooks(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

        public IEnumerable<MGradebook> GetAll()
        {
            using (SqlCommand command = new SqlCommand("EXEC GradebookGetAll", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<MGradebook> gradebook = new List<MGradebook>();
                    while (reader.Read())
                        gradebook.Add(CreateGradebook(reader));

                    return gradebook;
                }
            }
        }

        public MGradebook GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC GradebookGetById @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateGradebook(reader);

                    return null;
                }
            }
        }

        public IEnumerable<MGradebook> GetAllEditable()
        {
            using (SqlCommand command = new SqlCommand("EXEC GradebookGetAllEditable", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<MGradebook> gradebook = new List<MGradebook>();
                    while (reader.Read())
                        gradebook.Add(CreateGradebook(reader));

                    return gradebook;
                }
            }
        }

        public int Insert(MGradebook gradebook)
        {
            if (gradebook == null)
                throw new ArgumentNullException("gradebook", "Valid gradebook is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC GradebookInsert @PClassId, @SchoolYearStart, @SchoolYearEnd, @Editable", connection))
            {
                command.Parameters.Add("@PClassId", SqlDbType.Int).Value = gradebook.PClassId;
                command.Parameters.Add("@SchoolYearStart", SqlDbType.DateTime).Value = gradebook.SchoolYearStart;
                command.Parameters.Add("@SchoolYearEnd", SqlDbType.DateTime).Value = gradebook.SchoolYearEnd;
                command.Parameters.Add("@Editable", SqlDbType.Bit).Value = gradebook.Editable;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(MGradebook gradebook)
        {
            if (gradebook == null)
                throw new ArgumentNullException("gradebook", "Valid gradebook is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC GradebookUpdate @Id, @GradebookId, @SubjectId, @LessonTheme, @Date", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = gradebook.Id;
                command.Parameters.Add("@GradebookId", SqlDbType.Int).Value = gradebook.PClassId;
                command.Parameters.Add("@SubjectId", SqlDbType.DateTime).Value = gradebook.SchoolYearStart;
                command.Parameters.Add("@LessonTheme", SqlDbType.DateTime).Value = gradebook.SchoolYearEnd;
                command.Parameters.Add("@Date", SqlDbType.Bit).Value = gradebook.Editable;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(MGradebook gradebook)
        {
            if (gradebook == null)
                throw new ArgumentNullException("gradebook", "Valid gradebook is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC GradebookDelete @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = gradebook.Id;

                command.ExecuteNonQuery();
            }
        }

        private MGradebook CreateGradebook(IDataReader reader)
        {
            return new MGradebook((int)reader["Id"], (int)reader["PClassId"], (DateTime)reader["SchoolYearStart"], (DateTime)reader["SchoolYearEnd"], (bool)reader["Editable"]);
        }
    }
}
