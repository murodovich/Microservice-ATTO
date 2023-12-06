using MediatR;
using University.Application.Absreactions;
using University.Application.PaswordHash;
using University.Application.UseCases.Students.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.Students.Handlers
{
    public class CreateStudentCommandHandler : AsyncRequestHandler<CreateStudentCommand>
    {
        private readonly IUniversityDBContext _dbContext;

        public CreateStudentCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Age = request.Age,
                Country = request.Country,
                Password = Hash512.ComputeSHA512HashFromString(request.Password),
                UserName = request.UserName,
                City = request.City,
                Gender = request.Gender,
                GroupId = request.GroupId,
                Role = request.Role,
                CreatedAt = request.CreatedAt,

            };

            await _dbContext.students.AddAsync(student);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
