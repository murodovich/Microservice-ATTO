using MediatR;
using System.ComponentModel.DataAnnotations;
using Transport.Domain.Enums;

namespace Transport.Application.UseCases.Users.Commonds
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$")]
        public string Password { get; set; }
        public Role Role { get; set; }
        [RegularExpression(@"^(\+998|\b998)([1-9][0-9]{8})$")]
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
