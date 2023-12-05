using MediatR;

namespace University.Application.UseCases.Subjects.Commands
{
    public class UpdateSubjectCommand : IRequest<bool>
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
