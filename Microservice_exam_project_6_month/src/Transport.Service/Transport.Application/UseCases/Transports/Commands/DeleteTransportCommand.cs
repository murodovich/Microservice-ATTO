using MediatR;

namespace Transport.Application.UseCases.Transports.Commands
{
    public class DeleteTransportCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
