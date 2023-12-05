namespace University.Domain.Exceptions.Attendanceis
{
    public class AttendanceNotFoundException : NotFoundException
    {
        public AttendanceNotFoundException() 
        {
            this.TitleMessage = "Attendance not Found !";
        }

    }
}
