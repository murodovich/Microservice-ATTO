using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Transports.Queries;
using Transport.Domain.Exceptions.Transports;

namespace Transport.Application.UseCases.Transports.Handler
{
    public class GetByIdTransportQueryHandler : IRequestHandler<GetByIdTransportQuery, Domain.Entities.Transports.Transport>
    {
        private readonly ITransportDBContext _dbContext;

        public GetByIdTransportQueryHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Entities.Transports.Transport> Handle(GetByIdTransportQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.transports.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new TransportNotFoundException();
            return result;
        }
    }
}
