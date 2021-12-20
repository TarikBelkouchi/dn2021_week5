using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DatabaseConsole
{
    //Entity Framework ("EF")


    public class Student
    {
        public int studentID { get; set; }
        public string Name { get; set; }
    }

    public class Course
    {
        public int courseID { get; set; }
        public string CourseName { get; set; }

    }

    public class  SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=efconsole1;User Id=sa;Password=MyPass@word;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What student would you like to add?");
            string entry = Console.ReadLine();
            using (SchoolContext context = new SchoolContext())
            {
                Student st = new Student() { Name = "Bill" };
                context.Students.Add(st);
                

                Student st2 = new Student() { Name = "Julia" };
                context.Students.Add(st2);

                context.SaveChanges();


            }
            Console.WriteLine("All done!");

        }
    }
}
