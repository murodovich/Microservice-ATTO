namespace University.Domain.Exceptions.CourseGroup
{
    public class CourseGroupNotFoundExceptions : NotFoundException
    {
        public CourseGroupNotFoundExceptions()
        {
            this.TitleMessage = "CourseGroup not Found!";
        }
    }
}
