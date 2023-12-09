using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Models;

namespace University.Infrastructure.Configuration.CourseGroups
{
    public class CourseGroupConfiguration : IEntityTypeConfiguration<CourseGroup>
    {
        public void Configure(EntityTypeBuilder<CourseGroup> builder)
        {
            builder.ToTable("CourseGroups");

            builder.HasKey(cg => cg.CourseGroupId);

            builder.Property(cg => cg.CourseId)
                .IsRequired();

            builder.Property(cg => cg.GroupId)
                .IsRequired();



            builder.HasOne(cg => cg.Group)
                .WithMany(g => g.Courses)
                .HasForeignKey(cg => cg.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
