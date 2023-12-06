using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Routes.Queries;
using Transport.Domain.Entities.Routeis;
using Transport.Domain.Exceptions.Routes;

namespace Transport.Application.UseCases.Routes.Handler
{
    public class GetByIdRoudeQueryHandler : IRequestHandler<GetByIdRouteQuery, Route>
    {
        private readonly ITransportDBContext _dbContext;

        public GetByIdRoudeQueryHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Route> Handle(GetByIdRouteQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.routes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new RouteNotFoundException();
            return result;

        }
    }
}
