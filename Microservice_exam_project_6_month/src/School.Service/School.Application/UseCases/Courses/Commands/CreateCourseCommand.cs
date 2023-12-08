using MediatR;

namespace School.Application.UseCases.Courses.Commands
{
    public class CreateCourseCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public int SubjectId { get; set; }       
        public int TeacherId { get; set; }
    }
}
