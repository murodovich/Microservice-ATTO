using MediatR;
using School.Application.Absreactions;
using School.Application.UseCases.Students.Commands;
using School.Domain.Entities.Students;
using School.Domain.Enums;

namespace School.Application.UseCases.Students.Handler
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly ISchoolDbContext _dbContext;

        public CreateStudentCommandHandler(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = new Student()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                Age = request.Age,
                Email = request.Email,
                BirthDate = request.BirthDate,
                CreatedAt = DateTime.Now,
                Role = Role.Student,

            };

            await _dbContext.students.AddAsync(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
