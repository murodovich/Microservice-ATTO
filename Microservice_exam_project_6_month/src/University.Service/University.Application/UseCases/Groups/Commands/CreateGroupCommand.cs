using MediatR;

namespace University.Application.UseCases.Groups.Commands
{
    public class CreateGroupCommand : IRequest<bool>
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int Lavel {  get; set; }
    }
}
