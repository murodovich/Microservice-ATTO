namespace University.Domain.Exceptions.Subject
{
    public class SubjectNotFoundException : NotFoundException
    {
        public SubjectNotFoundException()
        {
            TitleMessage = "Subject not Found !";
        }
    }
}
