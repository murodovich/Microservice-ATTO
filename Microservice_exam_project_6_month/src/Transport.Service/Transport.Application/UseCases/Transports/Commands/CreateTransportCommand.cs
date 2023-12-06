using MediatR;

namespace Transport.Application.UseCases.Transports.Commands
{
    public class CreateTransportCommand : IRequest<bool>
    {
        public string TransportName { get; set; }
        public string TransportType { get; set; }
        public int Capacity { get; set; }
    }
}
