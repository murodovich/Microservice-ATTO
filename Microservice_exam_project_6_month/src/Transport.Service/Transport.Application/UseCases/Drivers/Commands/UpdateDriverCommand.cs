using MediatR;

namespace Transport.Application.UseCases.Drivers.Commands
{
    public class UpdateDriverCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int TransportId { get; set; }
        public int LicenseNumber { get; set; }
        public string DriverName { get; set; }
    }
}
