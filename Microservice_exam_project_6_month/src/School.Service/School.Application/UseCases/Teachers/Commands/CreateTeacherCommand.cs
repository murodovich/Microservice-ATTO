using MediatR;
using School.Domain.Enums;

namespace School.Application.UseCases.Teachers.Commands
{
    public class CreateTeacherCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
