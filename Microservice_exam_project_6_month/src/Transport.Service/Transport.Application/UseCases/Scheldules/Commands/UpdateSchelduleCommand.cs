using MediatR;

namespace Transport.Application.UseCases.Scheldules.Commands
{
    public class UpdateSchelduleCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public int TransportId { get; set; }
        public int RouteId { get; set; }
    }
}
