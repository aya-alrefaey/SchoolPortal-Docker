using Microsoft.EntityFrameworkCore;
using student_mvc.Configurations;
using student_mvc.Models;

namespace student_mvc.contexts
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentDbContext).Assembly);
        }
        public DbSet<Student> Students { get; set; }
    }
}
