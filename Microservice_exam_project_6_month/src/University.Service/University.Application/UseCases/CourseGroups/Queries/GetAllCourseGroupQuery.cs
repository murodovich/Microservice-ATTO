using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.CourseGroups.Queries
{
    public class GetAllCourseGroupQuery :IRequest<List<CourseGroup>>
    {
    }
}
