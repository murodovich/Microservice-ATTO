using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Subjects.Queries;
using School.Domain.Entities.Subjects;

namespace School.Application.UseCases.Subjects.Handler
{
    public class GetAllSubjectQueryHandler : IRequestHandler<GetAllSubjectQuery, List<Subject>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllSubjectQueryHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.subjects.ToListAsync();
            return result;
        }
    }
}
