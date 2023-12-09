using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Models;

namespace University.Infrastructure.Configuration.Lessons
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons");

            builder.HasKey(l => l.LessonId);

            builder.Property(l => l.CourseId)
                .IsRequired();

            builder.Property(l => l.LessonName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(l => l.Date)
                .IsRequired();
        }
    }
}
