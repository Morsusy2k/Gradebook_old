namespace Gradebook.DataAccessLayer.Models
{
    public class Subject
    {
        public Subject() { }
        public Subject(int id, int userId, string name)
        {
            Id = id;
            UserId = userId;
            Name = name;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
