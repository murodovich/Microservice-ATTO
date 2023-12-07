namespace School.Domain.Exceptions.Teachers
{
    public class TeacherNotFoundException : NotFoundException
    {
        public TeacherNotFoundException()
        {
            this.TitleMessage = "Teacher not Found!";
        }
    }
}
