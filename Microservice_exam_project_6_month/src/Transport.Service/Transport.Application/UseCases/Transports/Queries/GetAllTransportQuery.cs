using MediatR;

namespace Transport.Application.UseCases.Transports.Queries
{
    public class GetAllTransportQuery : IRequest<List<Domain.Entities.Transports.Transport>>
    { 
    }
}
