using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.DataAccessLayer.Models;
using Phonebook.DataAccessLayer.DBAccess;

namespace Gradebook.DataAccessLayer.DBAccess
{
    public class SubjectLessons
    {
        private readonly SqlConnection connection;

        internal SubjectLessons(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

        public IEnumerable<SubjectLesson> GetAll()
        {
            using (SqlCommand command = new SqlCommand("EXEC SubjectLessonGetAll", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<SubjectLesson> subjectsLessons = new List<SubjectLesson>();
                    while (reader.Read())
                        subjectsLessons.Add(CreateSubjectLesson(reader));

                    return subjectsLessons;
                }
            }
        }

        public SubjectLesson GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC SubjectLessonGetById @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateSubjectLesson(reader);

                    return null;
                }
            }
        }

        public IEnumerable<SubjectLesson> GetAllByGradebookId(MGradebook gradebook)
        {
            using (SqlCommand command = new SqlCommand("EXEC SubjectLessonGetAllByGradebookId @Id", connection))
            {
                command.Parameters.Add("@Id",SqlDbType.Int).Value = gradebook.Id;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<SubjectLesson> subjectsLessons = new List<SubjectLesson>();
                    while (reader.Read())
                        subjectsLessons.Add(CreateSubjectLesson(reader));

                    return subjectsLessons;
                }
            }
        }

        public int Insert(SubjectLesson subjectLesson)
        {
            if (subjectLesson == null)
                throw new ArgumentNullException("subjectLesson", "Valid subject lesson is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC SubjectLessonInsert @GradebookId, @SubjectId, @LessonTheme, @Date, @TimeOfLesson", connection))
            {
                command.Parameters.Add("@GradebookId", SqlDbType.Int).Value = subjectLesson.GradebookId;
                command.Parameters.Add("@SubjectId", SqlDbType.Int).Value = subjectLesson.SubjectId;
                command.Parameters.Add("@LessonTheme", SqlDbType.NVarChar).Value = subjectLesson.LessonTheme.Optional();
                command.Parameters.Add("@Date", SqlDbType.DateTime).Value = subjectLesson.Date;
                command.Parameters.Add("@TimeOfLesson", SqlDbType.NVarChar).Value = subjectLesson.TimeOfLesson;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(SubjectLesson subjectLesson)
        {
            if (subjectLesson == null)
                throw new ArgumentNullException("subjectLesson", "Valid subjectLesson is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC SubjectLessonUpdate @Id, @GradebookId, @SubjectId, @LessonTheme, @Date, @TimeOfLesson", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = subjectLesson.Id;
                command.Parameters.Add("@GradebookId", SqlDbType.Int).Value = subjectLesson.GradebookId;
                command.Parameters.Add("@SubjectId", SqlDbType.Int).Value = subjectLesson.SubjectId;
                command.Parameters.Add("@LessonTheme", SqlDbType.NVarChar).Value = subjectLesson.LessonTheme.Optional();
                command.Parameters.Add("@Date", SqlDbType.DateTime).Value = subjectLesson.Date;
                command.Parameters.Add("@TimeOfLesson", SqlDbType.NVarChar).Value = subjectLesson.TimeOfLesson;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(SubjectLesson subjectLesson)
        {
            if (subjectLesson == null)
                throw new ArgumentNullException("subjectLesson", "Valid subjectLesson is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC SubjectLessonDelete @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = subjectLesson.Id;

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<SubjectLessonsAbsentees> GetAllAbsenteesBySubjectLessonId(SubjectLesson subjectLesson)
        {
            using (SqlCommand command = new SqlCommand("EXEC SubjectLessonAbsenteesGetAllById", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<SubjectLessonsAbsentees> absentees = new List<SubjectLessonsAbsentees>();
                    while (reader.Read())
                        absentees.Add(CreateSubjectLessonAbsentee(reader));

                    return absentees;
                }
            }
        }

        public int InsertPupilAbsentee(SubjectLesson subjectLesson, Pupil pupil)
        {
            if (subjectLesson == null)
                throw new ArgumentNullException("subjectLesson", "Valid subject lesson is mandatory!");

            if (pupil == null)
                throw new ArgumentNullException("pupil", "Valid pupil is mandatory!");

            using (SqlCommand command = new SqlCommand("EXEC SubjectLessonInsertAbsentee @SubjectLessonId, @PupilId", connection))
            {
                command.Parameters.Add("@SubjectLessonId", SqlDbType.Int).Value = subjectLesson.Id;
                command.Parameters.Add("@PupilId", SqlDbType.Int).Value = pupil.Id;

                return (int)command.ExecuteScalar();
            }
        }

        public void DeleteAbsentee(int id)
        {
            using (SqlCommand command = new SqlCommand("EXEC SubjectLessonDeleteAbsentee @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
        }

        private SubjectLesson CreateSubjectLesson(IDataReader reader)
        {
            return new SubjectLesson((int)reader["Id"], (int)reader["GradebookId"], (int)reader["SubjectId"], (DateTime)reader["Date"], reader["TimeOfLesson"] as string, reader["LessonTheme"] as string);
        }

        private SubjectLessonsAbsentees CreateSubjectLessonAbsentee(IDataReader reader)
        {
            return new SubjectLessonsAbsentees((int)reader["Id"], (int)reader["SubjectLessonId"], (int)reader["PupilId"]);
        }
    }
}
