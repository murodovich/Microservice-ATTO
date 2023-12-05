namespace University.Domain.Exceptions.Dedlineis
{
    public class DedlineNotFoundException : NotFoundException 
    {
        public DedlineNotFoundException()
        {
            this.TitleMessage = "Dedline not Found !";
        }
    }
}
