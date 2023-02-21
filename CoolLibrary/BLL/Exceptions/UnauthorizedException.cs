namespace CoolLibrary.BLL.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base($"Access is denied")
        {
        }
    }
}