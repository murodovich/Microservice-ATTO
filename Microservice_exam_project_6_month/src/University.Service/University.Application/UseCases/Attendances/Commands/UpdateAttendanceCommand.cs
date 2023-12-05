using MediatR;

namespace University.Application.UseCases.Attendances.Commands
{
    public class UpdateAttendanceCommand : IRequest<bool>
    {
        public int AttendanceId { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public bool Attendances { get; set; }
    }
}
