using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Teachers.Queries
{
    public class GetAllTeacherQuerie : IRequest<List<Teacher>>
    {
    }
}
