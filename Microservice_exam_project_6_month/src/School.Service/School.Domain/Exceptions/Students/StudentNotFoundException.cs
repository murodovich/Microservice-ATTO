namespace School.Domain.Exceptions.Students
{
    public class StudentNotFoundException : NotFoundException
    {
        public StudentNotFoundException()
        {
            this.TitleMessage = "Student not Found!";
        }
    }
}
