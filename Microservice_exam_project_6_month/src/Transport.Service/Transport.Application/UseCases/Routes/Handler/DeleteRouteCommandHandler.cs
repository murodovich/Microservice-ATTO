using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Routes.Commands;
using Transport.Domain.Exceptions.Routes;

namespace Transport.Application.UseCases.Routes.Handler
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public DeleteRouteCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.routes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new RouteNotFoundException();

            _dbContext.routes.Remove(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
