using MediatR;
using School.Application.Absreactions;
using School.Application.UseCases.StudentCourses.Commands;
using School.Domain.Entities.StudentCourses;

namespace School.Application.UseCases.StudentCourses.Handler
{
    public class CreateStudentCourseCommandHandler : IRequestHandler<CreateStudentCourseCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateStudentCourseCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateStudentCourseCommand request, CancellationToken cancellationToken)
        {
            var result = new StudentCourse()
            {
                CourseId = request.CourseId,
                StudentId = request.StudentId,
                Grade = request.Grade,
            };
            await _context.studentsCourse.AddAsync(result);
            var res = await _context.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
