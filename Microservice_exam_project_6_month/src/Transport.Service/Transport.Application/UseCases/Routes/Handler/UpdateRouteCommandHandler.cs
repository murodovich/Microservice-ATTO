using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Routes.Commands;
using Transport.Domain.Exceptions.Routes;

namespace Transport.Application.UseCases.Routes.Handler
{
    public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public UpdateRouteCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.routes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new RouteNotFoundException();

            result.RouteName = request.RouteName;
            result.StartLocation = request.StartLocation;
            result.EndLocation = request.EndLocation;

            _dbContext.routes.Update(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
