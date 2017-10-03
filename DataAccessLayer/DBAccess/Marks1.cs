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
    public class Marks1
    {
        private readonly SqlConnection connection;

        internal Marks1(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

        public IEnumerable<Mark> GetAll()
        {
            using (SqlCommand command = new SqlCommand("EXEC MarkGetAll", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Mark> marks = new List<Mark>();
                    while (reader.Read())
                        marks.Add(CreateMark(reader));

                    return marks;
                }
            }
        }

        public Mark GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC MarkGetById @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateMark(reader);

                    return null;
                }

            }
        }

        public IEnumerable<Mark> GetAllByMarksId(Marks tmarks)
        {
            using (SqlCommand command = new SqlCommand("EXEC MarkGetAllByMarksId @Id", connection))
            {
                command.Parameters.Add("@Id",SqlDbType.Int).Value = tmarks.Id;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Mark> marks = new List<Mark>();
                    while (reader.Read())
                        marks.Add(CreateMark(reader));

                    return marks;
                }
            }
        }

        public int Insert(Mark mark)
        {
            if (mark == null)
                throw new ArgumentException("mark", "Valid mark is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC MarkInsert @MarksId, @Mark", connection))
            {
                command.Parameters.Add("@MarksId", SqlDbType.Int).Value = mark.MarksId;
                command.Parameters.Add("@Mark", SqlDbType.Int).Value = mark._Mark;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(Mark mark)
        {
            if (mark == null)
                throw new ArgumentNullException("mark", "Valid mark is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC MarkUpdate @Id, @MarksId, @Mark", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = mark.Id;
                command.Parameters.Add("@MarksId", SqlDbType.Int).Value = mark.MarksId;
                command.Parameters.Add("@Mark", SqlDbType.Int).Value = mark._Mark;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Mark mark)
        {
            if (mark == null)
                throw new ArgumentNullException("mark", "Valid mark is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC MarkDelete @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = mark.Id;

                command.ExecuteNonQuery();
            }
        }

        private Mark CreateMark(IDataReader reader)
        {
            return new Mark((int)reader["Id"], (int)reader["MarksId"], (int)reader["_Mark"]);
        }
    }
}
