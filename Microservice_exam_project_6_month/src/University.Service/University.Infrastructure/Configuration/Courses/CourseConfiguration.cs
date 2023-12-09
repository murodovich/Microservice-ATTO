using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Models;

namespace University.Infrastructure.Configuration.Courses
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.CourseName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.SubjectId)
                .IsRequired();

            builder.Property(c => c.TeacherId)
                .IsRequired();

            builder.HasMany(c => c.Courses)
                .WithOne(cg => cg.Course)
                .HasForeignKey(cg => cg.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
