namespace Transport.Domain.Exceptions.Drivers
{
    public class DriverNotFoundException : NotFoundException
    {
        public DriverNotFoundException()
        {
            this.TitleMessage = "Not Found Driver!";
        }
    }
}
