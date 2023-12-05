using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Dtos;
using University.Application.UseCases.Students.Commands;
using University.Application.UseCases.Students.Queries;

namespace University.Api.Controllers
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

        [HttpPost]
        public async ValueTask<IActionResult> CreateStudent(StudentDto studentDto)
        {
            var command = new CreateStudentCommand()
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                Age = studentDto.Age,
                Country = studentDto.Country,
                City = studentDto.City,
                Gender = studentDto.Gender,
                GroupId = studentDto.GroupId,
                Role = studentDto.Role,
                CreatedAt = studentDto.CreatedAt,
                UpdatedAt = studentDto.UpdatedAt,
            };

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
        public async ValueTask<IActionResult> UpdateStudent(int id, StudentDto studentDto)
        {
            var command = new UpdateStudentCommand()
            {
                StudentId = id,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                Age = studentDto.Age,
                Country = studentDto.Country,
                City = studentDto.City,
                Gender = studentDto.Gender,
                GroupId = studentDto.GroupId,
                Role = studentDto.Role,
                CreatedAt = studentDto.CreatedAt,
                UpdatedAt = studentDto.UpdatedAt,
            };

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
