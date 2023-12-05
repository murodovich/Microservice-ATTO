namespace University.Domain.Exceptions.TaskGrade
{
    public class TaskGradeNotFoundException : NotFoundException
    {
        public TaskGradeNotFoundException()
        {
            TitleMessage = "TaskGrade not Found !";
        }
    }
}
