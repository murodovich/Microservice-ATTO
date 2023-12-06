namespace Transport.Domain.Exceptions.Payments
{
    public class PaymentNotFoundException : NotFoundException
    {
        public PaymentNotFoundException()
        {
            this.TitleMessage = "Payment Not Found!";
        }
    }
}
