using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Students.Queries
{
    public class GetStudentCommand : IRequest<List<Student>>
    {
    }
}
