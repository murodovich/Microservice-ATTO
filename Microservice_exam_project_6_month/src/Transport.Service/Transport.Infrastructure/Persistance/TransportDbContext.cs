using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Domain.Entities.Drivers;
using Transport.Domain.Entities.Payments;
using Transport.Domain.Entities.Routeis;
using Transport.Domain.Entities.Schedules;
using Transport.Domain.Entities.Users;

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

    }
}
