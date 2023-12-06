using MediatR;

namespace Transport.Application.UseCases.Users.Commonds
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
