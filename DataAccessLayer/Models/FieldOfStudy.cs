namespace Gradebook.DataAccessLayer.Models
{
    public class FieldOfStudy
    {
        public FieldOfStudy() { }
        public FieldOfStudy(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
