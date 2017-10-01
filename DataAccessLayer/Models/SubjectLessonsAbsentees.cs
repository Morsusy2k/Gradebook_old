using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.DataAccessLayer.Models
{
    public class SubjectLessonsAbsentees
    {
        public SubjectLessonsAbsentees() { }
        public SubjectLessonsAbsentees(int id, int subjectLessonId, int pupilId)
        {
            Id = id;
            SubjectLessonId = subjectLessonId;
            PupilId = pupilId;
        }

        public int Id { get; set; }
        public int SubjectLessonId { get; set; }
        public int PupilId { get; set; }
    }
}
