using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Scheldules.Commands;
using Transport.Domain.Exceptions.Scheldules;

namespace Transport.Application.UseCases.Scheldules.Handler
{
    public class DeleteSchelduleCommandHandler : IRequestHandler<DeleteSchelduleCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public DeleteSchelduleCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteSchelduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.schedules.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new SchelduleNotFoundException();

            _dbContext.schedules.Remove(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
