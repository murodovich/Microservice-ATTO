using MediatR;
using Transport.Domain.Entities.Routeis;

namespace Transport.Application.UseCases.Routes.Queries
{
    public class GetByIdRouteQuery : IRequest<Route>
    {
        public int Id { get; set; }
    }
}
