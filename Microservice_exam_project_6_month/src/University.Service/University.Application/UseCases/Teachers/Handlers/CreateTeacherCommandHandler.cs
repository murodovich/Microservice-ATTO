using MediatR;
using University.Application.Absreactions;
using University.Application.UseCases.Teachers.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.Teachers.Handlers
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public CreateTeacherCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = new Teacher();
            teacher.FirstName = request.FirstName;
            teacher.LastName = request.LastName;
            teacher.FatherName = request.FatherName;
            teacher.Address = request.Address;
            teacher.Gender = request.Gender;
            teacher.Direction = request.Direction;
            teacher.Role = request.Role;
            teacher.CreatedAt = request.CreatedAt;


            await _dbContext.teachers.AddAsync(teacher);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
