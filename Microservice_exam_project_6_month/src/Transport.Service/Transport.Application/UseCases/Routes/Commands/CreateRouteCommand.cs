using MediatR;

namespace Transport.Application.UseCases.Routes.Commands
{
    public class CreateRouteCommand : IRequest<bool>
    {
        public string RouteName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
    }
}
