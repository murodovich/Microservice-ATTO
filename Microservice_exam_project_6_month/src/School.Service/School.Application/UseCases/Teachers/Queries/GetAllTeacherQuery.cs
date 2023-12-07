using MediatR;
using School.Domain.Entities.Teachers;

namespace School.Application.UseCases.Teachers.Queries
{
    public class GetAllTeacherQuery : IRequest<List<Teacher>>
    {
    }
}
