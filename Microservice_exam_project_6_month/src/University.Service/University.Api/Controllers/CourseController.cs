using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Dtos;
using University.Application.UseCases.Courses.Commands;
using University.Application.UseCases.Courses.Queries;

namespace University.Api.Controllers
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
        public async ValueTask<IActionResult> GetAllCourse()
        {
            var result = await _mediator.Send(new GetCourseCommand());
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCourse(CourseDto course)
        {
            var courses = new CreateCourseCommand()
            {
                CourseName = course.CourseName,
                SubjectId = course.SubjectId,
                TeacherId = course.TeacherId,
            };
            
            await _mediator.Send(courses);
            return Ok("Created Course");

        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdCourse(int id)
        {
            var course = new GetByIdCourseCommand()
            {
                Id = id
            };
            var result = await _mediator.Send(course);
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCourse(int id, CourseDto course)
        {
            var result = new UpdateCourseCommand()
            {
                Id = id,
                CourseName = course.CourseName,
                SubjectId = course.SubjectId,
                TeacherId = course.TeacherId,
            };
            await _mediator.Send(result);
            return Ok("Course Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeletedCourse(int id)
        {
            var result = new DeleteCourseCommand()
            {
                Id= id
            };
            await _mediator.Send(result);
            return Ok("Course Deleted");

        }
    }
}
