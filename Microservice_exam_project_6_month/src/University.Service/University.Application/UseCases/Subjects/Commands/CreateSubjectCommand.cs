using MediatR;

namespace University.Application.UseCases.Subjects.Commands
{
    public class CreateSubjectCommand : IRequest<bool>
    {
        public string SubjectName { get; set; }
    }
}
