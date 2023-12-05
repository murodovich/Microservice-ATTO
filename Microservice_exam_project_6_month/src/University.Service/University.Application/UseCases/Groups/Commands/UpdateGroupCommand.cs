using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.UseCases.Groups.Commands
{
    public class UpdateGroupCommand : IRequest<bool>
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int Lavel { get; set; }
    }
}
