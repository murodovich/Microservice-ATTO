namespace University.Domain.Exceptions.Students
{
    public class StudentsNotFoundException : NotFoundException
    {
        public StudentsNotFoundException()
        {
            this.TitleMessage = "Student Not Found !";
        }

    }
}
