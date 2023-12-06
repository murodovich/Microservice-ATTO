using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities.Transports;

namespace Transport.Infrastructure.Configuration.Transports
{
    public class TransportConfiguration : IEntityTypeConfiguration<Domain.Entities.Transports.Transport>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Transports.Transport> builder)
        {
            builder.ToTable("Transports");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.TransportName).IsRequired().HasMaxLength(255);
            builder.Property(t => t.TransportType).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Capacity).IsRequired();

            

            builder.HasMany(t => t.drivers)
                   .WithOne(d => d.Transport)
                   .HasForeignKey(d => d.TransportId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.schedules)
                   .WithOne(s => s.Transport)
                   .HasForeignKey(s => s.TransportId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
