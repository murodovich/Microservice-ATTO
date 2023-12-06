using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities.Schedules;

namespace Transport.Infrastructure.Configuration.Scheldules
{
    public class SchelduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.DepartureTime).IsRequired();

            builder.HasOne(s => s.Route)
                   .WithMany(r => r.Schedules)
                   .HasForeignKey(s => s.RouteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Transport)
                   .WithMany(t => t.schedules)
                   .HasForeignKey(s => s.TransportId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
