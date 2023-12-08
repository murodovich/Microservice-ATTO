using MediatR;
using School.Domain.Enums;

namespace School.Application.UseCases.StudentCourses.Commands
{
    public class CreateStudentCourseCommand : IRequest<bool>
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Grade? Grade { get; set; }
    }
}
