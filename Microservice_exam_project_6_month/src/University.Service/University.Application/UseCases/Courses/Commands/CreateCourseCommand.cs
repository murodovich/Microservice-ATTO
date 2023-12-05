 using MediatR;

namespace University.Application.UseCases.Courses.Commands
{
    public class CreateCourseCommand : IRequest<bool>
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

    }
}
