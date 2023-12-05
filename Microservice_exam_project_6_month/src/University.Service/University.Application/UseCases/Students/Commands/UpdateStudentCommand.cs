using MediatR;
using University.Domain.Enums;

namespace University.Application.UseCases.Students.Commands
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public int GroupId { get; set; }
    }
}
