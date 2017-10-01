using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class PClass
    {
        public PClass() { }
        public PClass(int id, int userId, int fieldOfStudyId, DateTime generation, string year, int pClassIndex)
        {
            Id = id;
            UserId = userId;
            FieldOfStudyId = fieldOfStudyId;
            Generation = generation;
            Year = year;
            PClassIndex = pClassIndex;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int FieldOfStudyId { get; set; }
        public DateTime Generation { get; set; }
        public string Year { get; set; }
        public int PClassIndex { get; set; }
    }
}
