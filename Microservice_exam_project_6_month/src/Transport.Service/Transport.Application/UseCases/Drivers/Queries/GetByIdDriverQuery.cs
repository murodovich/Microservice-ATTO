using MediatR;
using Transport.Domain.Entities.Drivers;

namespace Transport.Application.UseCases.Drivers.Queries
{
    public class GetByIdDriverQuery : IRequest<Driver>
    {
        public int Id { get; set; }

    }
}
