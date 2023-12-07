using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.Students;

namespace School.Infrastructure.Configuration.Students
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Password)
                .IsRequired()
                .HasMaxLength(255); 

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.Age)
                .IsRequired();

            builder.Property(s => s.BirthDate)
                .IsRequired();


            builder.HasMany(s => s.StudentCourses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId);

            builder.HasIndex(s => s.UserName).IsUnique();
            builder.HasIndex(s => s.Email).IsUnique();
        }
    }
}
