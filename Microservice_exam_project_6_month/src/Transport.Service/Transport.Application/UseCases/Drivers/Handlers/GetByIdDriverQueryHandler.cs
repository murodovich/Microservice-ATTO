using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Drivers.Queries;
using Transport.Domain.Entities.Drivers;
using Transport.Domain.Exceptions.Drivers;

namespace Transport.Application.UseCases.Drivers.Handlers
{
    public class GetByIdDriverQueryHandler : IRequestHandler<GetByIdDriverQuery, Driver>
    {
        private readonly ITransportDBContext _dbContext;

        public GetByIdDriverQueryHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Driver> Handle(GetByIdDriverQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.drivers.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new DriverNotFoundException();
            return result;
        }
    }
}
