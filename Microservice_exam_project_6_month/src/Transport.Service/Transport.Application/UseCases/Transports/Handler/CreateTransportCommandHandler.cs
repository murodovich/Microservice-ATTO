using MediatR;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Transports.Commands;

namespace Transport.Application.UseCases.Transports.Handler
{
    public class CreateTransportCommandHandler : IRequestHandler<CreateTransportCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public CreateTransportCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(CreateTransportCommand request, CancellationToken cancellationToken)
        {
            var result = new Domain.Entities.Transports.Transport()
            {
                TransportName = request.TransportName,
                Capacity = request.Capacity,
                TransportType = request.TransportType,
            };
            await _dbContext.transports.AddAsync(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
