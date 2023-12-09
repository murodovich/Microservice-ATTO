using System.ComponentModel.DataAnnotations.Schema;
using Transport.Domain.Entities.Users;
namespace Transport.Domain.Entities.Payments
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amaunt { get; set; }
        public DateTime PaymentDate { get; set; }
        [ForeignKey(nameof(Domain.Entities.Transports.Transport))]
        public int TransportId { get; set; }
        [ForeignKey(nameof(Domain.Entities.Users.User))]
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
