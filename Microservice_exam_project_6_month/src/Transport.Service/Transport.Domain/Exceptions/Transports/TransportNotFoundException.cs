namespace Transport.Domain.Exceptions.Transports
{
    public class TransportNotFoundException : NotFoundException
    {
        public TransportNotFoundException()
        {
            this.TitleMessage = "Not Found Exception!";
        }
    }
}
