using MediatR;

namespace Transport.Application.UseCases.Routes.Commands
{
    public class DeleteRouteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
