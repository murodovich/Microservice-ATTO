namespace School.Domain.Exceptions.Subjects
{
    public class SubjectNotFoundException : NotFoundException
    {
        public SubjectNotFoundException()
        {
            this.TitleMessage = "Subject Not Found!";
        }
    }
}
