using MediatR;

namespace University.Application.UseCases.TaskGrads.Commands
{
    public class CreateTaskGradeCommand : IRequest<bool>
    {
        public int DedlineId { get; set; }
        public int StudentId { get; set; }
        public string FilePath { get; set; }
    }
}
