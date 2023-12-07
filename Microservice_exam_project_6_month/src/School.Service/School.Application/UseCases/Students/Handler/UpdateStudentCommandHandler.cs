using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Students.Commands;
using School.Domain.Exceptions.Students;

namespace School.Application.UseCases.Students.Handler
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateStudentCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.students.FirstOrDefaultAsync(x => x.StudentId == request.Id);
            if (result == null) throw new StudentNotFoundException();

            result.FirstName = request.FirstName;
            result.LastName = request.LastName;
            result.Email = request.Email;
            result.UserName = request.UserName;
            result.Password = request.Password;
            result.Role = Domain.Enums.Role.Student;
            result.BirthDate = request.BirthDate;
            result.UpdatedAt = DateTime.Now;

            _context.students.Update(result);   
            var res = await _context.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
