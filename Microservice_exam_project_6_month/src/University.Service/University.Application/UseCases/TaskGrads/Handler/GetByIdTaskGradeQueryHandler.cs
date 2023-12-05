using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.TaskGrads.Queries;
using University.Domain.Exceptions.TaskGrade;
using University.Domain.Models;

namespace University.Application.UseCases.TaskGrads.Handler
{
    public class GetByIdTaskGradeQueryHandler : IRequestHandler<GetByIdTaskGradeQuery, TaskGrade>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetByIdTaskGradeQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskGrade> Handle(GetByIdTaskGradeQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.tasks.FirstOrDefaultAsync(x => x.TaskGradeId == request.Id);
            if (result == null) throw new TaskGradeNotFoundException();
            return result;
        }
    }
}
