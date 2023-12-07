using MediatR;
using School.Application.Absreactions;
using School.Application.UseCases.Teachers.Commands;
using School.Domain.Entities.Teachers;

namespace School.Application.UseCases.Teachers.Handler
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, bool>
    {
        private readonly ISchoolDbContext _dbContext;

        public CreateTeacherCommandHandler(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var result = new Teacher()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
                Role = Domain.Enums.Role.Teacher,
                Gender = request.Gender,
                CreatedAt = DateTime.UtcNow,

            };

            await _dbContext.teachers.AddAsync(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
