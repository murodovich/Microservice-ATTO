using System.ComponentModel.DataAnnotations.Schema;

namespace University.Domain.Entities.Models
{
    public class Dedline
    {
        public int DedlineId { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int MaxGrade { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public string FilePage { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }


    }
}
