using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Attendances.Queries;
using University.Domain.Exceptions.Attendanceis;
using University.Domain.Models;

namespace University.Application.UseCases.Attendances.Handler
{
    public class GetByIdAttendanceQueryHandler : IRequestHandler<GetByIdAttendanceQuery, Attendance>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetByIdAttendanceQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Attendance> Handle(GetByIdAttendanceQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.attendances.FirstOrDefaultAsync(x => x.AttendanceId == request.Id);
            if (result == null) throw new AttendanceNotFoundException();
            return result;
        }
    }
}
