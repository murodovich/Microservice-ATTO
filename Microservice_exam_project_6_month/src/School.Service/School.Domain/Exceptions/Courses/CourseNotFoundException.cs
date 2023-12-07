namespace School.Domain.Exceptions.Courses
{
    public class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException()
        {
            this.TitleMessage = "Course Not Found!";
        }
    }
}
