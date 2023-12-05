using MediatR;

namespace University.Application.UseCases.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
