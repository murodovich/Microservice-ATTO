using MediatR;
using University.Application.Absreactions;
using University.Application.UseCases.Attendances.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.Attendances.Handler
{
    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public UpdateAttendanceCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var result = new Attendance()
            {
                Attendances = request.Attendances,
                LessonId = request.LessonId,
                StudentId = request.StudentId,
            };
            _dbContext.attendances.Update(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
