using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Groups.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.Groups.Handler
{
    public class GetByIdGroupCommandHandler : IRequestHandler<GetByIdGroupCommand, Group>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetByIdGroupCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Group> Handle(GetByIdGroupCommand request, CancellationToken cancellationToken)
        {
            Group group = await _dbContext.groups.FirstOrDefaultAsync(x => x.GroupId == request.Id);
            return group;
        }
    }
}
