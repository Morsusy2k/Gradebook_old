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
    public class Markss
    {
        private readonly SqlConnection connection;

        internal Markss(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

        public IEnumerable<Marks> GetAll()
        {
            using (SqlCommand command = new SqlCommand("EXEC MarksGetAll", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Marks> marks = new List<Marks>();
                    while (reader.Read())
                        marks.Add(CreateMarks(reader));

                    return marks;
                }
            }
        }

        public Marks GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC MarksGetById @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateMarks(reader);

                    return null;
                }

            }
        }

        public IEnumerable<Marks> GetAllByUserId(User user)
        {
            using (SqlCommand command = new SqlCommand("EXEC MarksGetAllByPupilId @Id", connection))
            {
                command.Parameters.Add("@Id",SqlDbType.Int).Value = user.Id;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Marks> marks = new List<Marks>();
                    while (reader.Read())
                        marks.Add(CreateMarks(reader));

                    return marks;
                }
            }
        }

        public int Insert(Marks marks)
        {
            if (marks == null)
                throw new ArgumentException("marks", "Valid marks is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC MarksInsert @PupilId, @SubjectId, @FinalMark", connection))
            {
                command.Parameters.Add("@PupilId", SqlDbType.Int).Value = marks.PupilId;
                command.Parameters.Add("@SubjectId", SqlDbType.Int).Value = marks.SubjectId;
                command.Parameters.Add("@FinalMark", SqlDbType.Int).Value = marks.FinalMark;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(Marks marks)
        {
            if (marks == null)
                throw new ArgumentNullException("marks", "Valid marks is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC MarksUpdate @Id, @PupilId, @SubjectId, @FinalMark", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = marks.Id;
                command.Parameters.Add("@PupilId", SqlDbType.Int).Value = marks.PupilId;
                command.Parameters.Add("@SubjectId", SqlDbType.Int).Value = marks.SubjectId;
                command.Parameters.Add("@FinalMark", SqlDbType.Int).Value = marks.FinalMark;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Marks marks)
        {
            if (marks == null)
                throw new ArgumentNullException("marks", "Valid marks is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC MarksDelete @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = marks.Id;

                command.ExecuteNonQuery();
            }
        }

        private Marks CreateMarks(IDataReader reader)
        {
            return new Marks((int)reader["Id"], (int)reader["PupilId"], (int)reader["SubjectId"], (int)reader["FinalMark"]);//.DBNullTo<int?>()
        }
    }
}
