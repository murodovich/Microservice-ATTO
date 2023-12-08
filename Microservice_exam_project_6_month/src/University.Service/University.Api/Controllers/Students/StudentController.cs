using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using University.Application.UseCases.Students.Commands;
using University.Application.UseCases.Students.Queries;

namespace University.Api.Controllers.Students
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memorycashe;

        public StudentController(IMediator mediator, IMemoryCache memorycashe = null)
        {
            _mediator = mediator;
            _memorycashe = memorycashe;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateStudent([FromForm] CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created");

        }
        [HttpGet]
        public async ValueTask<IActionResult> GetStudent()
        {
            var student = await _mediator.Send(new GetStudentCommand());
            return Ok(student);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudent([FromForm] UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdStudent(int id)
        {
            var command = new GetByIdStudentCommand()
            {
                Id = id
            };
            var student = await _mediator.Send(command);
            return Ok(student);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteStudent(int id)
        {
            var command = new DeleteStudentCommand()
            {
                Id = id
            };
            await _mediator.Send(command);
            return Ok("Deleted");
        }

    }
}
