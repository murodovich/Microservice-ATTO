using MediatR;

namespace School.Application.UseCases.Courses.Commands
{
    public class DeleteCourseCommand : IRequest<bool>
    {
        public int id { get; set; }
    }
}
