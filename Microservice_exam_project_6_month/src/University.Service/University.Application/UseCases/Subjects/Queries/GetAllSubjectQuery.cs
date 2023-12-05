using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Subjects.Queries
{
    public class GetAllSubjectQuery : IRequest<List<Subject>>
    {
    }
}
