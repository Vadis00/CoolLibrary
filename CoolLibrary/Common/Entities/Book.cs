using CoolLibrary.Common.Entities.Abstract;

namespace CoolLibrary.Common.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            Ratings = new List<Rating>();
            Reviews = new List<Review>();
        }

        public string Title { get; set; } = null!;
        public string Cover { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;

        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
