using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.CourseGroups.Commands;
using University.Domain.Exceptions.CourseGroup;

namespace University.Application.UseCases.CourseGroups.Handler
{
    public class DeleteCourseGroupCommandHandler : IRequestHandler<DeleteCourseGroupCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public DeleteCourseGroupCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteCourseGroupCommand request, CancellationToken cancellationToken)
        {
            var res = await _dbContext.coursegroups.FirstOrDefaultAsync(x => x.CourseGroupId == request.Id);
            if (res == null) throw new CourseGroupNotFoundExceptions();
            _dbContext.coursegroups.Remove(res);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
