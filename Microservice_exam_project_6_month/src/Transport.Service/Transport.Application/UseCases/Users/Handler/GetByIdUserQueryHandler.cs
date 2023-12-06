using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Users.Queries;
using Transport.Domain.Entities.Users;
using Transport.Domain.Exceptions.Users;

namespace Transport.Application.UseCases.Users.Handler
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, User>
    {
        private readonly ITransportDBContext _dbContext;

        public GetByIdUserQueryHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new UserNotFoundException();
            return result;
        }
    }
}
