using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Drivers.Queries;
using Transport.Domain.Entities.Drivers;
using Transport.Domain.Exceptions.Drivers;

namespace Transport.Application.UseCases.Drivers.Handlers
{
    public class GetAllDriverQueryHandler : IRequestHandler<GetAllDriverQuery, List<Driver>>
    {
        private readonly ITransportDBContext _dbContext;

        public GetAllDriverQueryHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Driver>> Handle(GetAllDriverQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.drivers.ToListAsync();
            if(result == null) throw new DriverNotFoundException();

            return result;
        }
    }
}
