using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.Interfaces;
using University.Application.UseCases.Dedlineis.Commands;
using University.Domain.Exceptions.Dedlineis;

namespace University.Application.UseCases.Dedlineis.Handler
{
    public class UpdateDedlineCommandHandler : IRequestHandler<UpdateDedlineComman, bool>
    {
        private readonly IUniversityDBContext _dbContext;
        private readonly IFileService _fileService;

        public UpdateDedlineCommandHandler(IUniversityDBContext dbContext, IFileService fileService )
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }

        public async Task<bool> Handle(UpdateDedlineComman request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.dededlines.FirstOrDefaultAsync(x => x.DedlineId == request.DedlineId);
            if (result == null) throw new DedlineNotFoundException();
            string filepage = await _fileService.UploadImageAsync(request.FilePage);
            result.StartDate = request.StartDate;
            result.MaxGrade = request.MaxGrade;
            result.FilePage = filepage;
            result.CourseId = request.CourseId;

            _dbContext.dededlines.Update(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
