namespace School.Domain.Exceptions.StudentCourses
{
    public class StudentCourseNotFoundException : NotFoundException
    {
        public StudentCourseNotFoundException()
        {
            this.TitleMessage = "StudentCourse Not Found!";
        }
    }
}
