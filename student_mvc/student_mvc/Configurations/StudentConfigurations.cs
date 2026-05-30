using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using student_mvc.Models;

namespace student_mvc.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.LastName)
                .IsRequired() 
                .HasMaxLength(50);
            builder.Property(s => s.Email)
               .IsRequired()
               .HasMaxLength(100);
            builder.Property(s => s.Gender)
               .IsRequired()
               .HasConversion<int>();
            builder.Property(s => s.EnrollmentDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            builder.HasIndex(s => s.Email)
               .IsUnique();
            builder.Property(s => s.DateOfBirth)
               .IsRequired();
            builder.Property(s => s.Phone)
               .HasMaxLength(11)
               .IsRequired();

        }
    }
}
