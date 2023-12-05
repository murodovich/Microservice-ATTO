using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Courses.Commands
{
    public class GetByIdCourseCommand : IRequest<Course>
    {
        public int Id { get; set; }
    }
}
