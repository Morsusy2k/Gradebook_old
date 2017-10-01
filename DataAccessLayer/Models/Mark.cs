namespace Gradebook.DataAccessLayer.Models
{
    public class Mark
    {
        public Mark() { }
        public Mark(int id, int marksId, int mark)
        {
            Id = id;
            MarksId = marksId;
            _Mark = mark;
        }

        public int Id { get; set; }
        public int MarksId { get; set; }
        public int _Mark { get; set; }
    }
}
