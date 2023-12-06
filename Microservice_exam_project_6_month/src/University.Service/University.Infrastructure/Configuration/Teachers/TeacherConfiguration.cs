using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;
using University.Domain.Models;

namespace University.Infrastructure.Configuration.Teachers
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers"); 

            builder.HasKey(t => t.TeacherId);

            builder.Property(t => t.Gender)
                .HasConversion<string>();

            builder.Property(t => t.Role)
                .HasConversion<string>();

            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");

            builder.Property(x => x.Password)
                .HasMaxLength(8)
                .IsUnicode(true)
                .HasConversion(
                    x => x,
                    x => passwordRegex.IsMatch(x) ? x : "Invalid password format");

            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            builder.Property(x => x.Email)
           .IsRequired()
           .HasMaxLength(50)
           .IsUnicode(false)
           .HasConversion(
               v => v,
               v => emailRegex.IsMatch(v) ? v : "Invalid email format");

            builder.Property(t => t.UpdatedAt)
                .ValueGeneratedOnUpdate();

            builder.Ignore(t => t.CreatedAt);
            builder.Ignore(t => t.UpdatedAt);
        }
    }
}
