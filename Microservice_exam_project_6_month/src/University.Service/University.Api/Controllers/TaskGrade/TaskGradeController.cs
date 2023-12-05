using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.UseCases.TaskGrads.Commands;
using University.Application.UseCases.TaskGrads.Queries;

namespace University.Api.Controllers.TaskGrade
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskGradeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskGradeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateTaskGrade([FromForm] CreateTaskGradeCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllTaskGrade()
        {
            var res = await _mediator.Send(new GetAllTaskGradeQuery());
            return Ok(res);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateTaskGrade(UpdateTaskGradeCommand updateTaskGradeCommand)
        {
            await _mediator.Send(updateTaskGradeCommand);
            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdTaskGrade(int id)
        {
            var res = await _mediator.Send(new GetByIdTaskGradeQuery() { Id = id});
            return Ok(res);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteTaskGrade(int id)
        {
            await _mediator.Send(new DeleteTaskGradeCommand() { Id = id});
            return Ok("Deleted");
        }
    }
}
