using MediatR;
using School.Domain.Entities.Subjects;

namespace School.Application.UseCases.Subjects.Queries
{
    public class GetByIdSubjectQuery : IRequest<Subject>
    {
        public int Id { get; set; }
    }
}
