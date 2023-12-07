using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.Subjects;

namespace School.Infrastructure.Configuration.Subjects
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(s => s.SubjectId);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(s => s.Courses)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => s.Name).IsUnique();
        }
    }
}
