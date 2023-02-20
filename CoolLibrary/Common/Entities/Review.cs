using CoolLibrary.Common.Entities.Abstract;

namespace CoolLibrary.Common.Entities
{
    public class Review : BaseEntity
    {
        public string Message { get; set; } = null!;
        public string Reviewer { get; set; } = null!;
        public Book Book { get; set; } = null!;
    }
}
