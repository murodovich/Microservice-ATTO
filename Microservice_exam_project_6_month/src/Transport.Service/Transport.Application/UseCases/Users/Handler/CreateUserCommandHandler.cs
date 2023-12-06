using MediatR;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Users.Commonds;
using Transport.Domain.Entities.Users;

namespace Transport.Application.UseCases.Users.Handler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly ITransportDBContext _transportDBContext;

        public CreateUserCommandHandler(ITransportDBContext transportDBContext)
        {
            _transportDBContext = transportDBContext;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                CreatedAt = DateTime.UtcNow,
                Role  = request.Role,

            };
            await _transportDBContext.Users.AddAsync(user);
            var result = await _transportDBContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
