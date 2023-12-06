using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using University.Domain.Enums;

namespace University.Application.UseCases.Students.Commands
{
    public class CreateStudentCommand : IRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }
        [RegularExpression(@"^(\+998|\b998)([1-9][0-9]{8})$")]
        public string Phone { get; set; }
        public string UserName { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$")]
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int GroupId { get; set; }
    }
}
