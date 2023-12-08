using MediatR;
using School.Domain.Entities.StudentCourses;

namespace School.Application.UseCases.StudentCourses.Queries
{
    public class GetByIdStudentCourseQuery : IRequest<StudentCourse>
    {
        public int Id { get; set; }
    }
}
