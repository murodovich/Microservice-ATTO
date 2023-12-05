using MediatR;
using University.Application.Absreactions;
using University.Application.UseCases.CourseGroups.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.CourseGroups.Handler
{
    public class CreateCourseGroupCommandHandler : IRequestHandler<CreateCourseGroupCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public CreateCourseGroupCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateCourseGroupCommand request, CancellationToken cancellationToken)
        {
            var result = new CourseGroup()
            {
                CourseId = request.CourseId,
                GroupId = request.GroupId,
            };
            await _dbContext.coursegroups.AddAsync(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
