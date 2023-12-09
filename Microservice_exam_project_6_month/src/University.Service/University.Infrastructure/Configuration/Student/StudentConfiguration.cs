using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace University.Infrastructure.Configuration.Student
{
    public class StudentConfiguration : IEntityTypeConfiguration<Domain.Models.Student>
    {

        public void Configure(EntityTypeBuilder<Domain.Models.Student> builder)
        {
            builder.HasKey(a => a.StudentId);
            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            builder.Property(x => x.Email)
           .IsRequired()
           .HasMaxLength(50)
           .IsUnicode(false)
           .HasConversion(
               v => v,
               v => emailRegex.IsMatch(v) ? v : "Invalid email format");

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Password)
                .HasMaxLength(255)
                .IsUnicode(true)
                ;
            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);
            var phoneNumber = new Regex(@"^(\+998|\b998)([1-9][0-9]{9})$");
            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion(
                x => x,
                x => phoneNumber.IsMatch(x) ? x : "Invalid PhoneNumber format");
            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(50);







        }
    }
}
