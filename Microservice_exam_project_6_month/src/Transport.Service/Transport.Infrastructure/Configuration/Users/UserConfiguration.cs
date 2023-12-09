using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities.Users;
namespace Transport.Infrastructure.Configuration.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(15);
            builder.Property(u => u.CreatedAt)
                .IsRequired();
            builder.Property(u => u.UpdatedAt)
                .IsRequired();


            builder.Property(u => u.Role).HasConversion<string>();

            builder.HasMany(u => u.Payment)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
