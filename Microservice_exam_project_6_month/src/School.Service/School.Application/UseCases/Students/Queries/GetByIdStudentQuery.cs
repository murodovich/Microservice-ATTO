using MediatR;
using School.Domain.Entities.Students;

namespace School.Application.UseCases.Students.Queries
{
    public class GetByIdStudentQuery : IRequest<Student>
    {
        public int  Id { get; set; }
    }
}
