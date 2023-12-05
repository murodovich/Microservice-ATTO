using MediatR;
using University.Application.Absreactions;
using University.Application.UseCases.Attendances.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.Attendances.Handler
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public CreateAttendanceCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var result = new Attendance()
            {
                Attendances = request.Attendances,
                LessonId = request.LessonId,
                StudentId = request.StudentId,
            };
            await _dbContext.attendances.AddAsync(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
