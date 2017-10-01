using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class SubjectLesson
    {
        public SubjectLesson() { }
        public SubjectLesson(int id, int gradebookId, int subjectId, DateTime date, string timeOfLesson, string lessonTheme = null)
        {
            Id = id;
            GradebookId = gradebookId;
            SubjectId = subjectId;
            LessonTheme = lessonTheme;
            Date = date;
            TimeOfLesson = timeOfLesson;
        }

        public int Id { get; set; }
        public int GradebookId { get; set; }
        public int SubjectId { get; set; }
        public string LessonTheme { get; set; }
        public DateTime Date { get; set; }
        public string TimeOfLesson { get; set; }
    }
}
