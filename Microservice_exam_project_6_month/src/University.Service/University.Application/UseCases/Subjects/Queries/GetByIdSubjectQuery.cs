using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Subjects.Queries
{
    public class GetByIdSubjectQuery : IRequest<Subject>
    {
        public int Id { get; set; }

    }
}
