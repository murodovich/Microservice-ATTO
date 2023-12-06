using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Routes.Queries;
using Transport.Domain.Entities.Routeis;
using Transport.Domain.Exceptions.Routes;

namespace Transport.Application.UseCases.Routes.Handler
{
    public class GetAllRouteQueryHandler : IRequestHandler<GetAllRouteQuery, List<Route>>
    {
        private readonly ITransportDBContext _dbContext;

        public GetAllRouteQueryHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Route>> Handle(GetAllRouteQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.routes.ToListAsync();
            if (result == null) throw new RouteNotFoundException();
            return result;
        }
    }
}
