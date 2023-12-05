using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Courses.Commands;
using University.Domain.Exceptions.Courseis;

namespace University.Application.UseCases.Courses.Handler
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public UpdateCourseCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.courses.FirstOrDefaultAsync(x => x.CourseId == request.Id);
            if (result == null) throw new CourseNotFoundException();

            result.CourseName = request.CourseName;
            result.TeacherId = request.TeacherId;
            result.SubjectId = request.SubjectId;

            _dbContext.courses.Update(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
