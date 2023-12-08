using MediatR;

namespace School.Application.UseCases.Subjects.Commands
{
    public class DeleteSubjectCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
