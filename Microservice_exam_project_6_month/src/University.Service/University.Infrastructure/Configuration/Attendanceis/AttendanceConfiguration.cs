using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Models;

namespace University.Infrastructure.Configuration.Attendanceis
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendances");

            builder.HasKey(a => a.AttendanceId);

            builder.Property(a => a.LessonId)
                .IsRequired();

            builder.Property(a => a.StudentId)
                .IsRequired();

            builder.Property(a => a.Attendances)
                .IsRequired();

        }
    }
}
