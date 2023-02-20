using CoolLibrary.Common.Entities.Abstract;

namespace CoolLibrary.Common.Entities
{
    public class Rating : BaseEntity
    {
        public string Score { get; set; } = null!;
        public Book Book { get; set; } = null!;
    }
}
