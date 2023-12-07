using School.Domain.Entities.Courses;

namespace School.Domain.Entities.Teachers
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
