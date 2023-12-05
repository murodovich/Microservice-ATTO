using MediatR;

namespace University.Application.UseCases.CourseGroups.Commands
{
    public class DeleteCourseGroupCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
