using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.DataAccessLayer.Models
{
    public class FieldOfStudyHasSubjects
    {
        public FieldOfStudyHasSubjects() { }
        public FieldOfStudyHasSubjects(int id, int fieldOfStudyId, int subjectId)
        {
            Id = id;
            FieldOfStudyId = fieldOfStudyId;
            SubjectId = subjectId;
        }


        public int Id { get; set; }
        public int FieldOfStudyId { get; set; }
        public int SubjectId { get; set; }
    }
}
