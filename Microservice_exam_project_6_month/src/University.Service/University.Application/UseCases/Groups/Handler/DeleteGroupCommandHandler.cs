using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Groups.Commands;

namespace University.Application.UseCases.Groups.Handler
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public DeleteGroupCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.groups.FirstOrDefaultAsync(x => x.GroupId == request.Id);
            if (result == null)
            {
                return false;
            }
            _dbContext.groups.Remove(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;            
        }
    }
}
