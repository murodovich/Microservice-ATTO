using MediatR;

namespace School.Application.UseCases.Students.Commands
{
    public class CreateStudentCommand : IRequest<bool>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        
    }
}
