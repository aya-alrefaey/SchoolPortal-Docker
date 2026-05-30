using grade_mvc.contexts;
using grade_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace grade_mvc.data_seeding
{
    public static class GradeSeeder
    {
        public static async Task SeedGradesAsync(GradeDbContext context)
        {
           
            if (await context.Grades.AnyAsync())
                return;

            var grades = new List<Grade>
            {
                new Grade
                {
                    StudentId = 1,
                    CourseName = "OOP",
                    Score = 85,
                    GradeDate = DateTime.Now.AddDays(-10),
                    Notes = "Good understanding"
                },
                new Grade
                {
                    StudentId = 2,
                    CourseName = "Machine learning",
                    Score = 90,
                    GradeDate = DateTime.Now.AddDays(-9),
                    Notes = "Excellent performance"
                },
                new Grade
                {
                    StudentId = 3,
                    CourseName = "Data Structure",
                    Score = 78,
                    GradeDate = DateTime.Now.AddDays(-8),
                    Notes = "Needs improvement"
                },
                new Grade
                {
                    StudentId = 4,
                    CourseName = "Programming 2",
                    Score = 92,
                    GradeDate = DateTime.Now.AddDays(-7),
                    Notes= "Very Strong"
                }
            };

            await context.Grades.AddRangeAsync(grades);
            await context.SaveChangesAsync();
        }
    }
}
