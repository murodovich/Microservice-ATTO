using MediatR;

namespace School.Application.UseCases.StudentCourses.Commands
{
    public class DeleteStudentCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
