using MediatR;
using School.Domain.Enums;

namespace School.Application.UseCases.StudentCourses.Commands
{
    public class UpdateStudentCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int CourseId { get;  set; }
        public int StudentId { get; set;}
        public Grade? Grade { get; set; }
    }
}
