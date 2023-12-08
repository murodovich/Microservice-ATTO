using MediatR;
using School.Domain.Entities.Courses;

namespace School.Application.UseCases.Courses.Queries
{
    public class GetByIdCourseQuery : IRequest<Course>
    {
        public int Id { get; set; }
    }
}
