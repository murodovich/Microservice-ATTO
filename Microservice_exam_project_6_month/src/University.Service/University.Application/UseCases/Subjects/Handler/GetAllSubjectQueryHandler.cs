using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Subjects.Queries;
using University.Domain.Models;

namespace University.Application.UseCases.Subjects.Handler
{
    public class GetAllSubjectQueryHandler : IRequestHandler<GetAllSubjectQuery, List<Subject>>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetAllSubjectQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Subject>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.subjects.ToListAsync();
            return result;
        }
    }
}
