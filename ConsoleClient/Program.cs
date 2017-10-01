using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.DataAccessLayer.Models;

namespace Gradebook.DataAccessLayer.ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetAllUsers();
        }

        static void GetAllUsers()
        {
            Console.WriteLine();

            using (DBAccess.DBAGradebook gradebook = new DBAccess.DBAGradebook(Properties.Settings.Default.GradebookDbConnection))
            {
                foreach (User user in gradebook.Users.GetAll())
                {
                    Console.Write("  {0,-10}", "Id:");
                    Console.WriteLine("{0,-10}", user.Id);

                    Console.Write("  {0,-10}", "Name:");
                    Console.WriteLine("{0,-10}", user.Name);

                    Console.Write("  {0,-10}", "Surname:");
                    Console.WriteLine("{0,-10}", user.Surname);

                    Console.Write("  {0,-10}", "Email:");
                    Console.WriteLine("{0,-10}", user.Email);

                    Console.WriteLine("  {0,-10}", "Roles:");
                    foreach (Role role in gradebook.Roles.GetAllByUserId(user))
                    {
                        Console.WriteLine("\t-{0,-10}", role.Name);
                    }

                    Console.WriteLine("  {0,-10}", "Subjects:");
                    foreach (Subject sub in gradebook.Subjects.GetAllByUserId(user))
                    {
                        Console.WriteLine("\t-{0,-10}", sub.Name);
                    }

                    Console.WriteLine("  {0,-10}", "Classes:");
                    foreach (PClass cl in gradebook.PClasses.GetAllByUserId(user))
                    {
                        FieldOfStudy field = gradebook.FieldOfStudies.GetById(cl.FieldOfStudyId);
                        Console.WriteLine("\t-{0,-10}", field.Name);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
