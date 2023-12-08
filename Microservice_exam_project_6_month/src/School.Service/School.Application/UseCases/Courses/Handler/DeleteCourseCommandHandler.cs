using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Courses.Commands;
using School.Domain.Exceptions.Courses;

namespace School.Application.UseCases.Courses.Handler
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly ISchoolDbContext _dbContext;

        public DeleteCourseCommandHandler(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.courses.FirstOrDefaultAsync(x => x.CourseId == request.id);
            if (result == null) throw new CourseNotFoundException();

            _dbContext.courses.Remove(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;

        }
    }
}
