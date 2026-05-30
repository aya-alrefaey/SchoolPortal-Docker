using Microsoft.EntityFrameworkCore;
using student_mvc.contexts;
using student_mvc.enums;
using student_mvc.Models;

namespace student_mvc.data_seeding
{
    public static class StudentSeeder
    {

        public static async Task Seed(StudentDbContext context)
        {
           
            if (await context.Students.AnyAsync())
                return;

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Habiba",
                    LastName = "Azab",
                    Email = "habiba@gmail.com",
                    DateOfBirth = new DateTime(2001, 9, 15),
                    Gender = Gender.Female,
                    Address = "Cairo",
                    Phone = "01000000002",
                    EnrollmentDate = DateTime.Now.AddMonths(-5)
                   
                },
                new Student
                {
                    FirstName = "Ahmed",
                    LastName = "Azab",
                    Email = "ahmed@gmail.com",
                    DateOfBirth = new DateTime(2002, 5, 10),
                    Gender = Gender.Male,
                    Address = "Alexandria",
                    Phone = "01000000001",
                    EnrollmentDate = DateTime.Now.AddMonths(-3)
                },
                new Student
                {
                    FirstName = "Doha",
                    LastName = "Harby",
                    Email = "doha@gmail.com",
                    DateOfBirth = new DateTime(2001, 9, 15),
                    Gender = Gender.Female,
                    Address = "Cairo",
                    Phone = "01000000002",
                    EnrollmentDate = DateTime.Now.AddMonths(-5)
                },
                new Student
                {
                    FirstName = "Mohamed",
                    LastName = "Azab",
                    Email = "mohamed@gmail.com",
                    DateOfBirth = new DateTime(2003, 1, 20),
                    Gender = Gender.Male,
                    Address = "Giza",
                    Phone = "01000000003",
                    EnrollmentDate = DateTime.Now.AddMonths(-2)
                }
            };

            await context.Students.AddRangeAsync(students);
            await context.SaveChangesAsync();
        }
    }
}
