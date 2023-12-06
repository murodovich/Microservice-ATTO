using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Scheldules.Queries;
using Transport.Domain.Entities.Schedules;

namespace Transport.Application.UseCases.Scheldules.Handler
{
    public class GetAllSchelduleQueryHandler : IRequestHandler<GetAllSchelduleQuery, List<Schedule>>
    {
        private readonly ITransportDBContext _dbContext;

        public GetAllSchelduleQueryHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Schedule>> Handle(GetAllSchelduleQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.schedules.ToListAsync();
            return result;
        }
    }
}
