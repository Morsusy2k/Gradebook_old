namespace Gradebook.DataAccessLayer.Models
{
    public class User
    {
        public User() { }

        public User(int id, string name, string surname, string username, string password, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
