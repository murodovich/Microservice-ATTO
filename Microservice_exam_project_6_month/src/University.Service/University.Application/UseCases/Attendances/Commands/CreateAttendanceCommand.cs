using MediatR;

namespace University.Application.UseCases.Attendances.Commands
{
    public class CreateAttendanceCommand : IRequest<bool>
    {
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public bool Attendances { get; set; }
    }
}
