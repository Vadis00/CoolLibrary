using CoolLibrary.Common.Entities.Abstract;

namespace CoolLibrary.Common.Entities
{
    public class Rating : BaseEntity
    {
        public decimal Score { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}
