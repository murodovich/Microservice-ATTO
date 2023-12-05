using Azure.Core;
using MediatR;
using University.Application.Absreactions;
using University.Application.Interfaces;
using University.Application.UseCases.Dedlineis.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.Dedlineis.Handler
{
    public  class CreateDedlineCommandHandler : IRequestHandler<CreateDedlineCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;
        private readonly IFileService _fileService;
        public CreateDedlineCommandHandler(IUniversityDBContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }
        public async Task<bool> Handle(CreateDedlineCommand request, CancellationToken cancellationToken)
        {
            string filepage = await _fileService.UploadImageAsync(request.FilePage);


            var result = new Dedline()
            {
                MaxGrade = request.MaxGrade,
                StartDate =DateTime.Now,
                ExpiredDate = request.ExpiredDate,
                CourseId = request.CourseId,
                FilePage = filepage,            

            };
            await _dbContext.dededlines.AddAsync(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
