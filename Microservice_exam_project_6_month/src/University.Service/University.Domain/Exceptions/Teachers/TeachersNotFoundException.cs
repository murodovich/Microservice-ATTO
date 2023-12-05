namespace University.Domain.Exceptions.Teachers
{
    public class TeachersNotFoundException : NotFoundException
    {
        public TeachersNotFoundException()
        {
            this.TitleMessage = "Teacher not Found !";
        }
    }
}
