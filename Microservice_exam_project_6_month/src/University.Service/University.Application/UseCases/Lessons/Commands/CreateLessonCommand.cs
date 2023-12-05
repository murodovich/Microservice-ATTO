using MediatR;

namespace University.Application.UseCases.Lessons.Commands
{
    public class CreateLessonCommand : IRequest<bool>
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public string LessonName { get; set; }
        public DateTime Date { get; set; }
    }
}
