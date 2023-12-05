using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.TaskGrads.Queries
{
    public class GetAllTaskGradeQuery : IRequest<List<TaskGrade>>
    {
    }
}
