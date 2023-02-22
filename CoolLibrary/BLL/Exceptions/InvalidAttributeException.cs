namespace CoolLibrary.BLL.Exceptions
{
    public class InvalidAttributeException : Exception
    {
        public InvalidAttributeException(string message) : base($"Invalid value {message}")
        {
        }
    }
}