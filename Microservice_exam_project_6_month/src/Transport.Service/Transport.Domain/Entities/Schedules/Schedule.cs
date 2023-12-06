using System.ComponentModel.DataAnnotations.Schema;
using Transport.Domain.Entities.Routeis;

namespace Transport.Domain.Entities.Schedules
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime DepartureTime {  get; set; }
        public int TransportId { get; set; }

        [ForeignKey(nameof(Route))]
        public int RouteId { get; set; }

        public Route Route { get; set; }
        public Domain.Entities.Transports.Transport Transport { get; set; }

    }
}
