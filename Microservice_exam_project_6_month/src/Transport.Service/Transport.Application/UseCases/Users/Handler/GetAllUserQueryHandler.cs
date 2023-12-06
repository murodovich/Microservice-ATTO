using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Users.Queries;
using Transport.Domain.Entities.Users;

namespace Transport.Application.UseCases.Users.Handler
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly ITransportDBContext _dbContext;

        public GetAllUserQueryHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Users.ToListAsync();
            return result;
        }
    }
}
