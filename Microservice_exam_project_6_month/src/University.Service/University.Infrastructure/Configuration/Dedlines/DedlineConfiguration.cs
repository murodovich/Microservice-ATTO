using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Models;

namespace University.Infrastructure.Configuration.Dedlines
{
    public class DedlineConfiguration : IEntityTypeConfiguration<Dedline>
    {
        public void Configure(EntityTypeBuilder<Dedline> builder)
        {
            builder.ToTable("Dedlines");

            builder.HasKey(d => d.DedlineId);

            builder.Property(d => d.ExpiredDate)
                .IsRequired();

            builder.Property(d => d.MaxGrade)
                .IsRequired();

            builder.Property(d => d.StartDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(d => d.FilePage)
                .IsRequired();

        }
    }
}
