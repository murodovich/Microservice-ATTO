using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Students.Commands;
using University.Domain.Exceptions.Students;

namespace University.Application.UseCases.Students.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public UpdateStudentCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _dbContext.students.FirstOrDefaultAsync(x => x.StudentId == request.StudentId);
            if (student == null) throw new StudentsNotFoundException();

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.Phone = request.Phone;
            student.Age = request.Age;
            student.Country = request.Country;
            student.City = request.City;
            student.Gender = request.Gender;
            student.GroupId = request.GroupId;
            student.Role = request.Role;
            student.UpdatedAt = request.UpdatedAt;

            _dbContext.students.Update(student);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;

        }
    }
}
