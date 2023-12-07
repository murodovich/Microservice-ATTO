using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.Students.Commands;
using School.Application.UseCases.Students.Queries;

namespace School.Api.Controllers.Students
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllStudentSchool()
        {
            var result = await _mediator.Send(new GetAllStudentQuery());
            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateStudentSchool(CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created");
        }
        
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdStudentSchool(int id)
        {
            var result = await _mediator.Send(new GetByIdStudentQuery() { Id = id });
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudentSchool(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteStudentSchool(int Id)
        {
            await _mediator.Send(new DeleteStudentCommand() { Id = Id });
            return Ok("Deleted");
        }
    }
}
