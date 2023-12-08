using MediatR;

namespace School.Application.UseCases.Teachers.Commands
{
    public class DeleteTeacherCommand : IRequest<bool>
    {
        public int Id { get; set; } 
    }
}
