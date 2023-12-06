using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Transports.Queries;
using Transport.Domain.Exceptions.Transports;

namespace Transport.Application.UseCases.Transports.Handler
{
    public class GetAllTransportQueryCommand : IRequestHandler<GetAllTransportQuery, List<Domain.Entities.Transports.Transport>>
    {
        private readonly ITransportDBContext _dbContext;

        public GetAllTransportQueryCommand(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Entities.Transports.Transport>> Handle(GetAllTransportQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.transports.ToListAsync();
            if (result == null) throw new TransportNotFoundException();
            return result;
        }
    }
}
