using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using University.Domain.Models;

namespace University.Application.UseCases.CourseGroups.Commands
{
    public class CreateCourseGroupCommand :  IRequest<bool>
    {
        public int CourseId { get; set; }
        public int GroupId { get; set; }
    }
}
