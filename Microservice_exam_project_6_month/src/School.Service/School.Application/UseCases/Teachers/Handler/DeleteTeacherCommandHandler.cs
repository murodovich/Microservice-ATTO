using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Teachers.Commands;
using School.Domain.Exceptions.Teachers;

namespace School.Application.UseCases.Teachers.Handler
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public DeleteTeacherCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.teachers.FirstOrDefaultAsync(x => x.TeacherId == request.Id);
            if (result == null) throw new TeacherNotFoundException();

            _context.teachers.Remove(result);

            var res = await _context.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
