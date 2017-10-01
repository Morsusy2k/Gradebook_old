namespace Gradebook.DataAccessLayer.Models
{
    public class Marks
    {
        public Marks() { }
        public Marks(int id, int pupilId, int subjectId, int? finalMark = null)
        {
            Id = id;
            PupilId = pupilId;
            SubjectId = subjectId;
            FinalMark = finalMark;
        }

        public int Id { get; set; }
        public int PupilId { get; set; }
        public int SubjectId { get; set; }
        public int? FinalMark { get; set; }
    }
}
