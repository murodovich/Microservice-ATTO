using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Users.Commonds;

namespace Transport.Application.UseCases.Users.Handler
{
    public class UpdateUserCommanHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public UpdateUserCommanHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            result.UserName = request.UserName;
            result.Password = request.Password;
            result.Email = request.Email;
            result.FirstName = request.FirstName;
            result.LastName = request.LastName;
            result.UpdatedAt = DateTime.Now;
            result.Role = request.Role;
            result.PhoneNumber = request.PhoneNumber;

            _dbContext.Users.Update(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
