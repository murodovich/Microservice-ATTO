using MediatR;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Scheldules.Commands;
using Transport.Domain.Entities.Schedules;

namespace Transport.Application.UseCases.Scheldules.Handler
{
    public class CreateSchelduleCommandHandler : IRequestHandler<CreateSchelduleCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public CreateSchelduleCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateSchelduleCommand request, CancellationToken cancellationToken)
        {
            var result = new Schedule()
            {
                DepartureTime = DateTime.UtcNow,
                TransportId = request.TransportId,
                RouteId = request.RouteId,
            };

            await _dbContext.schedules.AddAsync(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
