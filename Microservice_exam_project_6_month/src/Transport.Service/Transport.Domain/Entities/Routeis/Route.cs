using Transport.Domain.Entities.Schedules;

namespace Transport.Domain.Entities.Routeis
{
    public class Route
    {
        public  int Id { get; set; }
        public string RouteName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public ICollection<Schedule> Schedules { get; set; }

    }
}
