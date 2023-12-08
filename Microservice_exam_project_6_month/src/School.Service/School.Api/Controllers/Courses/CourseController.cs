using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.Courses.Commands;
using School.Application.UseCases.Courses.Queries;

namespace School.Api.Controllers.Courses
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCourseSchool()
        {
            var result = await _mediator.Send(new GetAllCourseQuery());
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCourseSchool(CreateCourseCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdCourseSchool(int Id) 
        {
            var result = await _mediator.Send(new GetByIdCourseQuery() { Id = Id});
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCourseSchool(UpdateCourseCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCourseSchool(int Id)
        {
            await _mediator.Send(new DeleteCourseCommand() { id = Id });
            return Ok("Deleted");
        }

    }
}
