using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Scheldules.Commands;
using Transport.Domain.Exceptions.Scheldules;

namespace Transport.Application.UseCases.Scheldules.Handler
{
    public class UpdateSchelduleCommandHandler : IRequestHandler<UpdateSchelduleCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public UpdateSchelduleCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateSchelduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.schedules.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new SchelduleNotFoundException();

            result.DepartureTime = request.DepartureTime;
            result.TransportId = request.TransportId;
            result.RouteId = request.RouteId;

            _dbContext.schedules.Update(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
