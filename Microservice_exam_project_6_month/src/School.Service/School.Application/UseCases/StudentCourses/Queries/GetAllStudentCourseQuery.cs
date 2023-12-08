using MediatR;
using School.Domain.Entities.StudentCourses;

namespace School.Application.UseCases.StudentCourses.Queries
{
    public class GetAllStudentCourseQuer : IRequest<List<StudentCourse>>
    {
    }
}
