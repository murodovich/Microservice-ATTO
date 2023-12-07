using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.Teachers;

namespace School.Infrastructure.Configuration.Teachers
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.TeacherId);

            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(255); 

            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(255);

            
            builder.HasMany(t => t.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);

            builder.HasIndex(t => t.UserName).IsUnique();
            builder.HasIndex(t => t.Email).IsUnique();
        }
    }
}
