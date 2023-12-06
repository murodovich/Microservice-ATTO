using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCases.Users.Commonds;
using Transport.Application.UseCases.Users.Queries;

namespace Transport.Api.Controllers.Users
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllUser()
        {
            var result = await _mediator.Send(new GetAllUserQuery());
            return Ok(result);

        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateTransport(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetById(int Id)
        {
            var result = await _mediator.Send(new GetByIdUserQuery() { Id = Id });
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated User");

        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUser(int Id)
        {
            await _mediator.Send(new DeleteUserCommand() { Id = Id });
            return Ok("Deleted User");
        }


    }
}
