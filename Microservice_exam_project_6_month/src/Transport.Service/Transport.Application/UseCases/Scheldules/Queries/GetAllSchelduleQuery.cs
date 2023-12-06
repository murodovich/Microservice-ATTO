using MediatR;
using Transport.Domain.Entities.Schedules;

namespace Transport.Application.UseCases.Scheldules.Queries
{
    public class GetAllSchelduleQuery : IRequest<List<Schedule>>
    {
    }
}
