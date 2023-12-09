using System.ComponentModel.DataAnnotations.Schema;
namespace Transport.Domain.Entities.Drivers
{
    public class Driver
    {
        public int Id { get; set; }
        public string DriveName { get; set; }
        public int LicenseNumber { get; set; }
        [ForeignKey(nameof(Domain.Entities.Transports.Transport))]
        public int TransportId { get; set; }
        public Domain.Entities.Transports.Transport Transport { get; set; }

    }
}
