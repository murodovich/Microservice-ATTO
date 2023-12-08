using MediatR;

namespace School.Application.UseCases.Subjects.Commands
{
    public class UpdateSubjectCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
