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
        public async ValueTask<IActionResult> CreateLesson(CreateLessonCommand command)
        {
            var result = new CreateLessonCommand()
            {
                LessonName = command.LessonName,
                Date = command.Date,
                CourseId = command.CourseId

            };

            await _mediator.Send(result);
            return Ok("Created Lesson");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateLesson(UpdateLessonCommand command)
        {
            var result = new UpdateLessonCommand()
            {
                LessonName = command.LessonName,
                Date = command.Date,
                CourseId = command.CourseId
            };
            await _mediator.Send(result);
            return Ok("Updated Lesson");
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
