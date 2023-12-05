using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Lessons.Queries
{
    public class GetByIdLessonQuery : IRequest<Lesson>
    {
        public int Id { get; set; }
    }
}
