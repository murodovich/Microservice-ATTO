using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.StudentCourses.Commands;
using School.Domain.Exceptions.StudentCourses;

namespace School.Application.UseCases.StudentCourses.Handler
{
    public class UpdateStudentCourseCommandHandler : IRequestHandler<UpdateStudentCourseCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateStudentCourseCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateStudentCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.studentsCourse.FirstOrDefaultAsync(x => x.StudentCourseId == request.Id);
            if (result == null) throw new StudentCourseNotFoundException();

            result.CourseId = request.CourseId;
            result.StudentId = request.StudentId;
            result.Grade = request.Grade;

            _context.studentsCourse.Update(result);
            var res = await _context.SaveChangesAsync(cancellationToken);
            return res > 0;

        }
    }
}
