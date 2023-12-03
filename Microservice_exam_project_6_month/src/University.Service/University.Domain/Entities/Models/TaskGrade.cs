using System.ComponentModel.DataAnnotations.Schema;

namespace University.Domain.Entities.Models
{
    public class TaskGrade
    {
        public int TaskGradeId { get; set; }
        [ForeignKey(nameof(Dedline))]
        public int DedlineId { get; set; }
        public Dedline Dedline { get; set;}
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public string FilePath { get; set; }
    }
}
