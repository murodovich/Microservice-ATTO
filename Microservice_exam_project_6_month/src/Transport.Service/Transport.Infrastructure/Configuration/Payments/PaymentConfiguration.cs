using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities.Payments;

namespace Transport.Infrastructure.Configuration.Payments
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amaunt)
                .IsRequired();
            builder.Property(p => p.PaymentDate)
                .IsRequired();

            builder.HasOne(p => p.User)
                   .WithMany(u => u.Payment)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
