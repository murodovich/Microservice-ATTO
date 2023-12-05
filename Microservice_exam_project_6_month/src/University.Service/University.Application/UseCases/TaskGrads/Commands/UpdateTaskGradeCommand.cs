using MediatR;
using Microsoft.AspNetCore.Http;

namespace University.Application.UseCases.TaskGrads.Commands
{
    public class UpdateTaskGradeCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int DedlineId { get; set; }
        public int StudentId { get; set; }
        public IFormFile FilePath { get; set; }
    }
}
