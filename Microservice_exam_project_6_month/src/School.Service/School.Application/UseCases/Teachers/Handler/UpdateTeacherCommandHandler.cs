using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Teachers.Commands;
using School.Domain.Exceptions.Teachers;

namespace School.Application.UseCases.Teachers.Handler
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, bool>
    {
        private readonly ISchoolDbContext _dbContext;

        public UpdateTeacherCommandHandler(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.teachers.FirstOrDefaultAsync(x => x.TeacherId == request.Id);
            if (result == null) throw new TeacherNotFoundException();

            result.FirstName = request.FirstName;
            result.LastName = request.LastName;
            result.UserName = request.UserName;
            result.Email = request.Email;
            result.Password = request.Password;
            result.UpdatedAt = DateTime.UtcNow;
            result.Gender = request.Gender;

            _dbContext.teachers.Update(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
