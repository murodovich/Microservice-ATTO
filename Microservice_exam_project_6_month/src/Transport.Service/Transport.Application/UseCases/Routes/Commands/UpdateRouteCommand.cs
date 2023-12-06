using MediatR;

namespace Transport.Application.UseCases.Routes.Commands
{
    public class UpdateRouteCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
    }
}
