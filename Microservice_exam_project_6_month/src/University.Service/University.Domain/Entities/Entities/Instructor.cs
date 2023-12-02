namespace University.Domain.Entities.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Course> Courses { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
