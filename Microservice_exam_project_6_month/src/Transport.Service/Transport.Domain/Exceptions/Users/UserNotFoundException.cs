namespace Transport.Domain.Exceptions.Users
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() 
        {
            this.TitleMessage = "User Not Found!";
        }
    }
}
