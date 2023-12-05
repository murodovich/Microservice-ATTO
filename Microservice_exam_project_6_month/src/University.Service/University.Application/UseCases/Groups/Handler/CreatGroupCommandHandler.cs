using MediatR;
using University.Application.Absreactions;
using University.Application.UseCases.Groups.Commands;

namespace University.Application.UseCases.Groups.Handler
{
    public class CreatGroupCommandHandler : IRequestHandler<CreateGroupCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public CreatGroupCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Domain.Models.Group()
            {
                Name = request.Name,
                Level = request.Lavel
            };
            await _dbContext.groups.AddAsync(group);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}

