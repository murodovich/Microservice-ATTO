using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Models;

namespace University.Infrastructure.Configuration.Groups
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups"); 

            builder.HasKey(g => g.GroupId); 

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(g => g.Level)
                .IsRequired();

            builder.HasMany(g => g.Courses)
                .WithOne(cg => cg.Group)
                .HasForeignKey(cg => cg.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
