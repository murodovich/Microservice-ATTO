using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Teachers.Queries;
using School.Domain.Entities.Teachers;
using School.Domain.Exceptions.Teachers;

namespace School.Application.UseCases.Teachers.Handler
{
    public class GetByIdTeacherQueryHandler : IRequestHandler<GetByIdTeacherQuery, Teacher>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdTeacherQueryHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> Handle(GetByIdTeacherQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.teachers.FirstOrDefaultAsync(x => x.TeacherId == request.Id);
            if (result == null) throw new TeacherNotFoundException();
            return result;
        }
    }
}
