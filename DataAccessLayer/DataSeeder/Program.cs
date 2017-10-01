namespace Gradebook.DataAccessLayer.DataSeeder
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (DBAccess.DBAGradebook gradebook = new DBAccess.DBAGradebook(Properties.Settings.Default.GradebookDbConnection))
            {
                //TableChecker.CheckUserTable(gradebook);
                //TableChecker.CheckRoleTable(gradebook);
                //TableChecker.CheckSubjectTable(gradebook);
                //TableChecker.CheckSubjectLessonTable(gradebook);
                //TableChecker.CheckPupilTable(gradebook);
                //TableChecker.CheckMarksTable(gradebook);
                //TableChecker.CheckMarks1Table(gradebook);
                //TableChecker.CheckFieldOfStudyHasSubjectsTable(gradebook);
                //TableChecker.CheckLessonAbsentees(gradebook);
                TableChecker.CheckAllTables(gradebook);

            }
        }
    }
}
