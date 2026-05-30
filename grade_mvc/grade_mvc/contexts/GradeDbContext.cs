using grade_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace grade_mvc.contexts
{
    public class GradeDbContext: DbContext
    {
        public GradeDbContext(DbContextOptions<GradeDbContext> options) : base(options)
        {
        }
        public DbSet<Grade> Grades { get; set; }
    }
}
