using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Application.UseCases.Students.Commands;
using School.Application.UseCases.Students.Queries;

namespace School.Api.Controllers.Students
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public StudentController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllStudentSchool()
        {
            var casheddata = _memoryCache.Get("GetAll");
            if(casheddata == null)
            {
               var result =  await _mediator.Send(new GetAllStudentQuery());
                _memoryCache.Set("GetAll",result);

            }
          
            return Ok( _memoryCache.Get("GetAll"));
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateStudentSchool([FromForm]CreateStudentCommand command)
        {
            _memoryCache.Remove("GetAll");
            await _mediator.Send(command);
            return Ok("Created");
        }
        
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdStudentSchool(int id)
        {
            var res  = _memoryCache.Get(id);
            if (res == null)
            {
                var result = await _mediator.Send(new GetByIdStudentQuery() { Id = id });
                var res1 = _memoryCache.Set(id, result);
            }
            return Ok(_memoryCache.Get(id));
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudentSchool([FromForm] UpdateStudentCommand command)
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
