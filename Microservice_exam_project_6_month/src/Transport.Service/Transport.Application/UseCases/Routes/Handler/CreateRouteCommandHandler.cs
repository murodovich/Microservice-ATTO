using MediatR;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Routes.Commands;
using Transport.Domain.Entities.Routeis;

namespace Transport.Application.UseCases.Routes.Handler
{
    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public CreateRouteCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            var route = new Route()
            {
                RouteName = request.RouteName,
                EndLocation = request.EndLocation,
                StartLocation = request.StartLocation,
            };
            await _dbContext.routes.AddAsync(route);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
