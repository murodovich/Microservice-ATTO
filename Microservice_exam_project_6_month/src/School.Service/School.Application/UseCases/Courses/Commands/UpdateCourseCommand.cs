using MediatR;

namespace School.Application.UseCases.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }
}
