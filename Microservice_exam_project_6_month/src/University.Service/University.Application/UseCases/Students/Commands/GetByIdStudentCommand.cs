using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Students.Commands
{
    public class GetByIdStudentCommand : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
