namespace University.Domain.Exceptions.Courseis
{
    public class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException()
        {
            this.TitleMessage = "Course not Found !";
        }
    }
}
