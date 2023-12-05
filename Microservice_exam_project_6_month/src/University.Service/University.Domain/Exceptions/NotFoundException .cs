namespace University.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public string TitleMessage { get; set; } = string.Empty;
    }
}
