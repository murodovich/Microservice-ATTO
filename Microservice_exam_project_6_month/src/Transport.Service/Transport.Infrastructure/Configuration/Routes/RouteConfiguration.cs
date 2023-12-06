using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities.Routeis;

namespace Transport.Infrastructure.Configuration.Routes
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable("Routes");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.RouteName).IsRequired().HasMaxLength(255);
            builder.Property(r => r.StartLocation).IsRequired().HasMaxLength(255);
            builder.Property(r => r.EndLocation).IsRequired().HasMaxLength(255);

            builder.HasMany(r => r.Schedules)
                   .WithOne(s => s.Route)
                   .HasForeignKey(s => s.RouteId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
