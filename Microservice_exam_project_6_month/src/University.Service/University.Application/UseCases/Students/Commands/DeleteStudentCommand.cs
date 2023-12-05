using MediatR;

namespace University.Application.UseCases.Students.Commands
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
