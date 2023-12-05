using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.TaskGrads.Commands;
using University.Domain.Exceptions.TaskGrade;

namespace University.Application.UseCases.TaskGrads.Handler
{
    public class DeleteTaskGradeCommandHandler : IRequestHandler<DeleteTaskGradeCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public DeleteTaskGradeCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteTaskGradeCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.tasks.FirstOrDefaultAsync(x => x.TaskGradeId == request.Id);
            if (result == null) throw new TaskGradeNotFoundException();

            _dbContext.tasks.Remove(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
