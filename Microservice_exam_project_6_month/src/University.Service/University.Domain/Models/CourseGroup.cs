using System.ComponentModel.DataAnnotations.Schema;

namespace University.Domain.Models
{
    public class CourseGroup
    {
        public int CourseGroupId { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
