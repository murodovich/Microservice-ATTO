using MediatR;

namespace School.Application.UseCases.Students.Commands
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
