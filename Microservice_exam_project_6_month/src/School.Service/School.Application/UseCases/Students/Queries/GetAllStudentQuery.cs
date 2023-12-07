using MediatR;
using School.Domain.Entities.Students;

namespace School.Application.UseCases.Students.Queries
{
    public class GetAllStudentQuery : IRequest<List<Student>>
    {
    }
}
