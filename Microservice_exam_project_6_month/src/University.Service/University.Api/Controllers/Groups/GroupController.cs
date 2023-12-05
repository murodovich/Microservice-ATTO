using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Dtos;
using University.Application.UseCases.Groups.Commands;
using University.Application.UseCases.Groups.Queries;

namespace University.Api.Controllers.Groups
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllGroup()
        {
            var result = await _mediator.Send(new GetGroupCommand());
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateGroup(GroupDto groupDto)
        {
            var group = new CreateGroupCommand()
            {
                Name = groupDto.Name,
                Lavel = groupDto.Level
            };
            await _mediator.Send(group);
            return Ok("Created Group");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdGroup(int id)
        {
            var group = new GetByIdGroupCommand()
            {
                Id = id
            };
            var result = await _mediator.Send(group);
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateGroup(int Id, GroupDto groupDto)
        {
            var group = new UpdateGroupCommand()
            {
                GroupId = Id,
                Name = groupDto.Name,
                Lavel = groupDto.Level
            };
            await _mediator.Send(group);
            return Ok("Updated group");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteGroup(int id)
        {
            var group = new DeleteGroupCommand()
            {
                Id = id
            };
            await _mediator.Send(group);
            return Ok("Deleted group");
        }
    }
}
