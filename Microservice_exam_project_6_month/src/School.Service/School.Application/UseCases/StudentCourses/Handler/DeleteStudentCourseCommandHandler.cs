using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.StudentCourses.Commands;
using School.Domain.Exceptions.StudentCourses;

namespace School.Application.UseCases.StudentCourses.Handler
{
    public class DeleteStudentCourseCommandHandler : IRequestHandler<DeleteStudentCourseCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public DeleteStudentCourseCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteStudentCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.studentsCourse.FirstOrDefaultAsync(x => x.StudentCourseId == request.Id);
            if (result == null) throw new StudentCourseNotFoundException();

            _context.studentsCourse.Remove(result);
            var res = await _context.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
