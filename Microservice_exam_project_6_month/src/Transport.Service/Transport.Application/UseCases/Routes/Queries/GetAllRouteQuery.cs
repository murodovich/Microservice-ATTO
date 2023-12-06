using MediatR;
using Transport.Domain.Entities.Routeis;

namespace Transport.Application.UseCases.Routes.Queries
{
    public class GetAllRouteQuery : IRequest<List<Route>>
    {
    }
}
