using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Subjects.Queries;
using School.Domain.Entities.Subjects;
using School.Domain.Exceptions.Subjects;

namespace School.Application.UseCases.Subjects.Handler
{
    public class GetByIdSubjectQueryHandler : IRequestHandler<GetByIdSubjectQuery, Subject>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdSubjectQueryHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Subject> Handle(GetByIdSubjectQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.subjects.FirstOrDefaultAsync(x => x.SubjectId == request.Id);
            if (result == null) throw new SubjectNotFoundException();
            return result;
        }
    }
}
