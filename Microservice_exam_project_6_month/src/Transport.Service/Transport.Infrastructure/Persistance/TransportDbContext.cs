using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Domain.Entities.Drivers;
using Transport.Domain.Entities.Payments;
using Transport.Domain.Entities.Routeis;
using Transport.Domain.Entities.Schedules;
using Transport.Domain.Entities.Users;
using Transport.Infrastructure.Configuration.Drivers;
using Transport.Infrastructure.Configuration.Payments;
using Transport.Infrastructure.Configuration.Routes;
using Transport.Infrastructure.Configuration.Scheldules;
using Transport.Infrastructure.Configuration.Transports;
using Transport.Infrastructure.Configuration.Users;

namespace Transport.Infrastructure.Persistance
{
    public class TransportDbContext : DbContext,ITransportDBContext
    {
        public TransportDbContext(DbContextOptions<TransportDbContext> options) 
            : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Route> routes { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<Domain.Entities.Transports.Transport> transports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TransportConfiguration());
            modelBuilder.ApplyConfiguration(new DriverConfiguration());
            modelBuilder.ApplyConfiguration(new SchelduleConfiguration());
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
        }

    }
}
