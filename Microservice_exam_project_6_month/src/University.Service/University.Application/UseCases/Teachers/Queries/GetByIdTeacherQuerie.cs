using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Teachers.Queries
{
    public class GetByIdTeacherQuerie : IRequest<Teacher>
    {
        public int Id { get; set; }
    }
}
