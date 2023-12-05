using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.CourseGroups.Queries
{
    public class GetByIdCourseGroupQuery : IRequest<CourseGroup>
    {
        public int Id { get; set; }
    }
}
