using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Models;

namespace University.Infrastructure.Configuration.TaskGrads
{
    public class TaskGradeConfiguration : IEntityTypeConfiguration<TaskGrade>
    {
        public void Configure(EntityTypeBuilder<TaskGrade> builder)
        {
            builder.ToTable("TaskGrades");

            builder.HasKey(t => t.TaskGradeId);


            builder.Property(t => t.FilePath)
            .IsRequired();

            builder.HasIndex(t => t.DedlineId);
            builder.HasIndex(t => t.StudentId);
        }
    }
}
