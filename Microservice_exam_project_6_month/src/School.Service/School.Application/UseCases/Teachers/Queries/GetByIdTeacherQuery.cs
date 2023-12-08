using MediatR;
using School.Domain.Entities.Teachers;

namespace School.Application.UseCases.Teachers.Queries
{
    public class GetByIdTeacherQuery : IRequest<Teacher>
    {
        public int Id { get; set; }
    }
}
