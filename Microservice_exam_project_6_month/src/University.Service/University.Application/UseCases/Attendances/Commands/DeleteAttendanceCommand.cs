using MediatR;

namespace University.Application.UseCases.Attendances.Commands
{
    public class DeleteAttendanceCommand :  IRequest<bool>
    {
        public int Id { get; set; }
    }
}
