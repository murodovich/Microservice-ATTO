using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Transports.Commands;
using Transport.Domain.Exceptions.Transports;

namespace Transport.Application.UseCases.Transports.Handler
{
    public class DeleteTransportCommandHandler : IRequestHandler<DeleteTransportCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public DeleteTransportCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteTransportCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.transports.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new TransportNotFoundException();

            _dbContext.transports.Remove(result);   

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
