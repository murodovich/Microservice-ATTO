using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.Interfaces;
using University.Application.UseCases.TaskGrads.Commands;
using University.Domain.Exceptions.TaskGrade;

namespace University.Application.UseCases.TaskGrads.Handler
{
    public class UpdateTaskGradeCommandHandler : IRequestHandler<UpdateTaskGradeCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;
        private readonly IFileService _fileService;

        public UpdateTaskGradeCommandHandler(IUniversityDBContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }

        public async Task<bool> Handle(UpdateTaskGradeCommand request, CancellationToken cancellationToken)
        {
            string filepage = await _fileService.UploadImageAsync(request.FilePath);
            if (string.IsNullOrEmpty(filepage)) throw new FileNotFoundException(nameof(filepage));

            var res = await _dbContext.tasks.FirstOrDefaultAsync(x => x.TaskGradeId == request.Id);
            if (res != null) throw new TaskGradeNotFoundException();

            res.StudentId = request.StudentId;
            res.DedlineId = request.DedlineId;
            res.FilePath = filepage;

            _dbContext.tasks.Update(res);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
