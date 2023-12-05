using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Groups.Queries;
using University.Domain.Models;

namespace University.Application.UseCases.Groups.Handler
{
    public class GetGroupCommandHandler : IRequestHandler<GetGroupCommand, List<Group>>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetGroupCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Group>> Handle(GetGroupCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.groups.ToListAsync(cancellationToken);
            return result;
        }

    }
}
