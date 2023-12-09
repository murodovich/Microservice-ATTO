namespace Transport.Domain.Exceptions;
public class NotFoundException : Exception
{
    public string TitleMessage { get; set; }
}
