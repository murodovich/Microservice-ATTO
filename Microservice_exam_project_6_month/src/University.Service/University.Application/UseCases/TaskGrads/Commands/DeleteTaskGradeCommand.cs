using MediatR;

namespace University.Application.UseCases.TaskGrads.Commands
{
    public class DeleteTaskGradeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
