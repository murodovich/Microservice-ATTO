using MediatR;
using Transport.Domain.Entities.Schedules;

namespace Transport.Application.UseCases.Scheldules.Queries
{
    public class GetByIdSchelduleQuery : IRequest<Schedule>
    {
        public int Id { get; set; }
    }
}
