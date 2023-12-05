using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.UseCases.TaskGrads.Commands;

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
    }
}
