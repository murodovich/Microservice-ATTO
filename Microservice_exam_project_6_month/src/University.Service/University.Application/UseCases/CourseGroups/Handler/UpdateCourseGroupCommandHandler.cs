using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.CourseGroups.Commands;
using University.Domain.Exceptions.CourseGroup;

namespace University.Application.UseCases.CourseGroups.Handler
{
    public class UpdateCourseGroupCommandHandler : IRequestHandler<UpdateCourseGroupCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public UpdateCourseGroupCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateCourseGroupCommand request, CancellationToken cancellationToken)
        {

            var res = await _dbContext.coursegroups.FirstOrDefaultAsync(x => x.CourseGroupId == request.Id);
            if (res == null) throw new CourseGroupNotFoundExceptions();

            res.GroupId = request.GroupId;
            res.CourseId = request.CourseId;

            _dbContext.coursegroups.Update(res);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
