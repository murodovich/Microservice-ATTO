using MediatR;
using Transport.Domain.Entities.Users;

namespace Transport.Application.UseCases.Users.Queries
{
    public class GetAllUserQuery : IRequest<List<User>>
    {
    }
}
