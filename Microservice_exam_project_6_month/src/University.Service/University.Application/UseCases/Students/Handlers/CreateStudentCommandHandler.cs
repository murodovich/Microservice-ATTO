using MediatR;
using University.Application.Absreactions;
using University.Application.UseCases.Students.Commands;
using University.Domain.Entities.Models;

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
                City = request.City
            };

            await _dbContext.students.AddAsync(student);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
