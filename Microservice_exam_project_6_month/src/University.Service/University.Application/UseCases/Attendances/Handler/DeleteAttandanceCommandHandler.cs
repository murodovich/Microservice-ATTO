using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Attendances.Commands;
using University.Domain.Exceptions.Attendanceis;

namespace University.Application.UseCases.Attendances.Handler
{
    public class DeleteAttandanceCommandHandler : IRequestHandler<DeleteAttendanceCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public DeleteAttandanceCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.attendances.FirstOrDefaultAsync(x => x.AttendanceId == request.Id);
            if (result == null) throw new AttendanceNotFoundException();
            _dbContext.attendances.Remove(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
