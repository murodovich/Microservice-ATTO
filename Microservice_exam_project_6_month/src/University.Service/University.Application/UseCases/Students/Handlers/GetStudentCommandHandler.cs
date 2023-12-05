using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Students.Queries;
using University.Domain.Models;

namespace University.Application.UseCases.Students.Handlers
{
    public class GetStudentCommandHandler : IRequestHandler<GetStudentCommand, List<Student>>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetStudentCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> Handle(GetStudentCommand request, CancellationToken cancellationToken)
        {
            List<Student> student = await _dbContext.students.ToListAsync();
            if(student == null)
            {
                student = new List<Student>();
            }
            return student;
        }
    }
}
