using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Scheldules.Queries;
using Transport.Domain.Entities.Schedules;
using Transport.Domain.Exceptions.Scheldules;

namespace Transport.Application.UseCases.Scheldules.Handler
{
    public class GetByIdSchelduleQueryCommand : IRequestHandler<GetByIdSchelduleQuery, Schedule>
    {
        private readonly ITransportDBContext _dbContext;

        public GetByIdSchelduleQueryCommand(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Schedule> Handle(GetByIdSchelduleQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.schedules.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new SchelduleNotFoundException();
            return result;
        }
    }
}
