namespace CoolLibrary.BLL
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base($"Entity {message} not found")
        {
        }

        public NotFoundException(string message, int id) : base($"Entity {message} with id: {id} not found")
        {
        }
    }
}