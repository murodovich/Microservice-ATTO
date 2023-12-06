namespace Transport.Domain.Exceptions.Routes
{
    public class RouteNotFoundException : NotFoundException
    {
        public RouteNotFoundException()
        {
            this.TitleMessage = "Route not Found!";
        }
    }
}
