using MediatR;

namespace University.Application.UseCases.Lessons.Commands
{
    public class DeleteLessonCommand : IRequest<bool>
    {
        public  int Id { get; set; }
    }
}
