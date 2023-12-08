using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.StudentCourses.Commands;
using School.Application.UseCases.StudentCourses.Queries;

namespace School.Api.Controllers.StudentCourses
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentCourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllStudentCourseSchool()
        {
            var result = await _mediator.Send(new GetAllStudentCourseQuer());
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateStudentCourseSchool([FromForm]CreateStudentCourseCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdStudentCourseSchool(int id)
        {
            var result = await _mediator.Send(new GetByIdStudentCourseQuery() { Id = id });
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudentCourseSchool([FromForm]UpdateStudentCourseCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteStudentCourseSchool(int Id)
        {
            await _mediator.Send(new DeleteStudentCourseCommand() { Id = Id });
            return Ok("Deleted");
        }
    }
}
