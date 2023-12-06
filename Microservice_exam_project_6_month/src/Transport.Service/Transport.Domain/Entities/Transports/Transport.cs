using Transport.Domain.Entities.Drivers;
using Transport.Domain.Entities.Payments;
using Transport.Domain.Entities.Schedules;

namespace Transport.Domain.Entities.Transports
{
    public class Transport
    {
        public int Id { get; set; }
        public string TransportName { get; set; }
        public string TransportType { get; set; }
        public int Capacity { get; set; }
        public ICollection<Payment> payments { get; set; }
        public ICollection<Driver> drivers { get; set; }
        public ICollection<Schedule> schedules { get; set; }

        
    }
}
