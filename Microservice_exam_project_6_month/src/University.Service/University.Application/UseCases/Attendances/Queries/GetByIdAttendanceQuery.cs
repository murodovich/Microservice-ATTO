using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Attendances.Queries
{
    public class GetByIdAttendanceQuery : IRequest<Attendance>
    {
        public int Id { get; set; }

    }
}
