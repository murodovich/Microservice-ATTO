using MediatR;

namespace University.Application.UseCases.Students.Commands
{
    public class CreateStudentCommand : IRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Shaped { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
