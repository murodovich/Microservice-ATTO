using MediatR;
using Transport.Domain.Enums;

namespace Transport.Application.UseCases.Users.Commonds
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
