namespace University.Domain.Exceptions.FileExceptions
{
    public class FileNotValid :  Exception
    {
       
        public string message { get; set; }
        public FileNotValid() 
        {
            message = "File not Valid!";
        }
    }
}
