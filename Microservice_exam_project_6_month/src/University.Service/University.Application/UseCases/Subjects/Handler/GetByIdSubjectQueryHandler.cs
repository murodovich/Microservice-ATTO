using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Subjects.Queries;
using University.Domain.Exceptions.Subject;
using University.Domain.Models;

namespace University.Application.UseCases.Subjects.Handler
{
    public class GetByIdSubjectQueryHandler : IRequestHandler<GetByIdSubjectQuery, Subject>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetByIdSubjectQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subject> Handle(GetByIdSubjectQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.subjects.FirstOrDefaultAsync(x => x.SubjectId == request.Id);
            if (result == null) throw new SubjectNotFoundException();
            return result;
        }
    }
}
