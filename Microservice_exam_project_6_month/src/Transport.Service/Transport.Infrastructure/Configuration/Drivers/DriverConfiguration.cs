using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities.Drivers;

namespace Transport.Infrastructure.Configuration.Drivers
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Drivers");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.DriveName)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(d => d.LicenseNumber)
                .IsRequired();


        }
    }
}
