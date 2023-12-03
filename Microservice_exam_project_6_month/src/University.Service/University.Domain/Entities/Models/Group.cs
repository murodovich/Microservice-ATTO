namespace University.Domain.Entities.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }  
        public ICollection<CourseGroup> Courses { get; set; }
    }
}
