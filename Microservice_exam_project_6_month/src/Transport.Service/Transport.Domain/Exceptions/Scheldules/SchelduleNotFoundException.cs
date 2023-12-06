namespace Transport.Domain.Exceptions.Scheldules
{
    public class SchelduleNotFoundException : NotFoundException
    {
        public SchelduleNotFoundException()
        {
            this.TitleMessage = "Scheldule Not Found!";
        }
    }
}
