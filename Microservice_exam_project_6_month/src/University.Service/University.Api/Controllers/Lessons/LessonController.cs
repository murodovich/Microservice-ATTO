using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.UseCases.Lessons.Commands;
using University.Application.UseCases.Lessons.Queries;

namespace University.Api.Controllers.Lessons
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllLesson()
        {
            var result = await _mediator.Send(new GetAllLessonQuery());
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateLesson([FromForm] CreateLessonCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created Lesson");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateLesson([FromForm] UpdateLessonCommand command)
        {
            
            await _mediator.Send(command);
            return Ok("Updated Lesson");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdLesson(int id)
        {
            var result = await _mediator.Send(new GetByIdLessonQuery() { Id = id });
            return Ok(result);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteLesson(DeleteLessonCommand command)
        {
            var result = new DeleteLessonCommand()
            {
                Id = command.Id,
            };
            await _mediator.Send(result);
            return Ok("Deleted Lesson");
        }
    }
}
