using System.ComponentModel.DataAnnotations.Schema;

namespace University.Domain.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<CourseGroup> Courses { get; set; }

    }
}
