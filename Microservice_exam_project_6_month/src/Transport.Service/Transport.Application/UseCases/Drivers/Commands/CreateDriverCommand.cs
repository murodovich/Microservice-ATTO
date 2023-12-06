using MediatR;

namespace Transport.Application.UseCases.Drivers.Commands
{
    public class CreateDriverCommand : IRequest<bool>
    {
        public int TransportId { get; set; }
        public int LicenseNumber { get; set; }
        public string DriverName { get; set; }
    }
}
