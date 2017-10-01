using System;
using System.Data.SqlClient;

namespace Gradebook.DataAccessLayer.DBAccess
{
    public class DBAGradebook : IDisposable
    {
        private readonly SqlConnection connection;

        public Users Users { get; set; }
        public Roles Roles { get; set; }
        public Subjects Subjects { get; set; }
        public SubjectLessons SubjectLessons { get; set; }
        public PClasses PClasses { get; set; }
        public Gradebooks Gradebooks { get; set; }
        public FieldOfStudies FieldOfStudies { get; set; }
        public Pupils Pupils { get; set; }
        public Markss Markss { get; set; }
        public Marks1 Mark1 { get; set; }

        public DBAGradebook(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString", "Valid connection string is mandatory");

            connection = new SqlConnection(connectionString);
            connection.Open();

            Users = new Users(connection);
            Roles = new Roles(connection);
            Subjects = new Subjects(connection);
            SubjectLessons = new SubjectLessons(connection);
            PClasses = new PClasses(connection);
            Gradebooks = new Gradebooks(connection);
            FieldOfStudies = new FieldOfStudies(connection);
            Pupils = new Pupils(connection);
            Markss = new Markss(connection);
            Mark1 = new Marks1(connection);
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
