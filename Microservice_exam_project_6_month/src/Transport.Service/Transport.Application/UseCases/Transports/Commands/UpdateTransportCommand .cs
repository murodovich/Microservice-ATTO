using MediatR;

namespace Transport.Application.UseCases.Transports.Commands
{
    public class UpdateTransportCommand : IRequest<bool>
    {
        public  int Id { get; set; }
        public string TransportName { get; set; }
        public string TransportType { get; set; }
        public int Capacity { get; set; }
    }
}
