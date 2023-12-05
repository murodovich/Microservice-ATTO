namespace University.Domain.Exceptions.Lessons
{
    public class LessonsNotFoundException : NotFoundException
    {
        public LessonsNotFoundException()
        {
            this.TitleMessage = "Lesson not Found !";
        }
    }
}
