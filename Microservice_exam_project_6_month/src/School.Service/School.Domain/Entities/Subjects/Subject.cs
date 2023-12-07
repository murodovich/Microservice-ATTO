using School.Domain.Entities.Courses;

namespace School.Domain.Entities.Subjects
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
