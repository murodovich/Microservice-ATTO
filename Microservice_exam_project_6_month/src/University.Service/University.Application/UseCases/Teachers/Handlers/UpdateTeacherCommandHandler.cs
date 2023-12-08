using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.PaswordHash;
using University.Application.UseCases.Teachers.Commands;
using University.Domain.Exceptions.Teachers;

namespace University.Application.UseCases.Teachers.Handlers
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public UpdateTeacherCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.teachers.FirstOrDefaultAsync(x => x.TeacherId == request.Id);
            if (teacher == null) throw new TeachersNotFoundException();

            teacher.FirstName = request.FirstName;
            teacher.LastName = request.LastName;
            teacher.FatherName = request.FatherName;
            teacher.Address = request.Address;
            teacher.Gender = request.Gender;
            teacher.Direction = request.Direction;
            teacher.Role = request.Role;
            teacher.UpdatedAt = DateTime.UtcNow;
            teacher.UserName = request.UserName;
            teacher.Password = Hash512.ComputeSHA512HashFromString(request.Password);

            _dbContext.teachers.Update(teacher);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
