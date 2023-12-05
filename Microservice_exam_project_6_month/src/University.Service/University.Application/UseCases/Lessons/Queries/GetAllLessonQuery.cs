using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Lessons.Queries
{
    public class GetAllLessonQuery : IRequest<List<Lesson>>
    {
    }
}
