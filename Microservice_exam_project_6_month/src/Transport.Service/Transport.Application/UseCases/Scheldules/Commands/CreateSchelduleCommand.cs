using MediatR;

namespace Transport.Application.UseCases.Scheldules.Commands
{
    public class CreateSchelduleCommand : IRequest<bool>
    {
        public DateTime DepartureTime { get; set; }
        public int TransportId { get; set; }

        public int RouteId { get; set; }
    }
}
