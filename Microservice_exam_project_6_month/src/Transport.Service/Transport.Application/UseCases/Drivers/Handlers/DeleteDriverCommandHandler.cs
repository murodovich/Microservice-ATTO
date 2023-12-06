using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Drivers.Commands;
using Transport.Domain.Exceptions.Drivers;

namespace Transport.Application.UseCases.Drivers.Handlers
{
    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public DeleteDriverCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.drivers.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new DriverNotFoundException();

            _dbContext.drivers.Remove(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
