using MediatR;
using University.Application.Absreactions;
using University.Application.Interfaces;
using University.Application.UseCases.TaskGrads.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.TaskGrads.Handler
{
    public class CreateTaskGradeCommandHandler : IRequestHandler<CreateTaskGradeCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;
        private readonly IFileService _fileService;

        public CreateTaskGradeCommandHandler(IUniversityDBContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }

        public async Task<bool> Handle(CreateTaskGradeCommand request, CancellationToken cancellationToken)
        {
            string filepage = await _fileService.UploadImageAsync(request.FilePath);
            if (string.IsNullOrEmpty(filepage)) throw new FileNotFoundException(nameof(filepage));

            var result = new TaskGrade()
            {
                FilePath = filepage,
                DedlineId = request.DedlineId,
                StudentId = request.StudentId,
            };
            await _dbContext.tasks.AddAsync(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
