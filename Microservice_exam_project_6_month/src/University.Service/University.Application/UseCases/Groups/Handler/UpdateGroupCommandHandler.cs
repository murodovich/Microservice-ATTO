using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Groups.Commands;

namespace University.Application.UseCases.Groups.Handler
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public UpdateGroupCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _dbContext.groups.FirstOrDefaultAsync(x => x.GroupId == request.GroupId);

            group.Name = request.Name;
            group.Level = request.Lavel;

            _dbContext.groups.Update(group);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
