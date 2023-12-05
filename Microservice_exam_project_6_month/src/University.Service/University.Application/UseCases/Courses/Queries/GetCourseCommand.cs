using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Courses.Queries
{
    public class GetCourseCommand : IRequest<List<Course>>
    {
    }
}
