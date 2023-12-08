using MediatR;
using School.Domain.Entities.Courses;

namespace School.Application.UseCases.Courses.Queries
{
    public class GetAllCourseQuery : IRequest<List<Course>>
    {
    }
}
