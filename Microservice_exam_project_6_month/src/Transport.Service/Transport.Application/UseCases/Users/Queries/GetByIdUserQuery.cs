using MediatR;
using Transport.Domain.Entities.Users;

namespace Transport.Application.UseCases.Users.Queries
{
    public class GetByIdUserQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
