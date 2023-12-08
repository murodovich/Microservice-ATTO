using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async ValueTask<IActionResult> CreateGroup([FromForm] CreateGroupCommand group)
        {
            await _mediator.Send(group);
            return Ok("Created Group");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdGroup([FromForm] GetByIdGroupCommand command)
        {

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateGroup([FromForm] UpdateGroupCommand group)
        {

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
