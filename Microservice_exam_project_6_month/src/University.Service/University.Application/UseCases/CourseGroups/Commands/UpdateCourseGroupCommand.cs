using MediatR;

namespace University.Application.UseCases.CourseGroups.Commands
{
    public class UpdateCourseGroupCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int CourseId { get; set; }
    }
}
