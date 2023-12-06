using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Transports.Commands;
using Transport.Domain.Exceptions.Transports;

namespace Transport.Application.UseCases.Transports.Handler
{
    public class UpdateTransportCommandHandler : IRequestHandler<UpdateTransportCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public UpdateTransportCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateTransportCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.transports.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new TransportNotFoundException();

            result.TransportName = request.TransportName;
            result.TransportType = request.TransportType;
            result.Capacity = request.Capacity;

            _dbContext.transports.Update(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
