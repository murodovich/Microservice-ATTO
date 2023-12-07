using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Teachers.Queries;
using School.Domain.Entities.Teachers;

namespace School.Application.UseCases.Teachers.Handler
{
    public class GetAllTeacherQueryHandler : IRequestHandler<GetAllTeacherQuery, List<Teacher>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllTeacherQueryHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.teachers.ToListAsync();
            return result;
        }
    }
}
