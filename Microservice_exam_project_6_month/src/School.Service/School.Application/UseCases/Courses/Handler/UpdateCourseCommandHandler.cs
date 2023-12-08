using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Courses.Commands;
using School.Domain.Exceptions.Courses;

namespace School.Application.UseCases.Courses.Handler
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateCourseCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.courses.FirstOrDefaultAsync(x => x.CourseId == request.Id);
            if (result == null) throw new CourseNotFoundException();

            result.Name = request.Name;
            result.TeacherId = request.TeacherId;
            result.SubjectId = request.SubjectId;

            _context.courses.Update(result);
            var res = await _context.SaveChangesAsync(cancellationToken);
            return res > 0;


        }
    }
}
