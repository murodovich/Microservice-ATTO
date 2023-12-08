using MediatR;

namespace School.Application.UseCases.Subjects.Commands
{
    public class CreateSubjectCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
