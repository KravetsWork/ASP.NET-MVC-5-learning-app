using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManyToManyApp.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }

    public class CourseDbInitializer : DropCreateDatabaseAlways<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            Student s1 = new Student { Id = 1, Name = "Egor", Surname = "Ivanov" };
            Student s2 = new Student { Id = 2, Name = "Olga", Surname = "Korol" };
            Student s3 = new Student { Id = 3, Name = "Oksana", Surname = "Ivanovna" };

            context.Students.Add(s1);
            context.Students.Add(s2);
            context.Students.Add(s3);

            Course c1 = new Course
            {
                Id = 1,
                Name = "Programming",
                Students = new List<Student>() { s1, s2, s3 }
            };
            Course c2 = new Course
            {
                Id = 1,
                Name = "CSS",
                Students = new List<Student>() { s1, s3 }
            };
            Course c3 = new Course
            {
                Id = 1,
                Name = "HTML",
                Students = new List<Student>() { s2, s3 }
            };
            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);

            context.SaveChanges();
        }
    }
}

