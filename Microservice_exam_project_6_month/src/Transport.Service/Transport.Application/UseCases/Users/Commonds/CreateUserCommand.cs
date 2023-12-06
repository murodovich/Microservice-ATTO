using MediatR;
using Transport.Domain.Enums;

namespace Transport.Application.UseCases.Users.Commonds
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
