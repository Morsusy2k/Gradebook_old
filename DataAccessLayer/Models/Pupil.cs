namespace Gradebook.DataAccessLayer.Models
{
    public class Pupil
    {
        public Pupil() { }
        public Pupil(int id, int pClassId, string name)
        {
            Id = id;
            PClassId = pClassId;
            Name = name;
        }

        public int Id { get; set; }
        public int PClassId { get; set; }
        public string Name { get; set; }
    }
}
