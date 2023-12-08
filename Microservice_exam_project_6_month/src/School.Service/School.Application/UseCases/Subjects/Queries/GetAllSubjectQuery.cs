using MediatR;
using School.Domain.Entities.Subjects;

namespace School.Application.UseCases.Subjects.Queries
{
    public class GetAllSubjectQuery : IRequest<List<Subject>>
    {
    }
}
