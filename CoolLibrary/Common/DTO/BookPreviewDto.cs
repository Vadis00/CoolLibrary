using CoolLibrary.Common.Entities;

namespace CoolLibrary.Common.DTO
{
    public class BookPreviewDto
    {
        public BookPreviewDto()
        {
            Reviews = new List<ReviewDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public decimal Rating { get; set; }
        public virtual ICollection<ReviewDto> Reviews { get; set; }

    }
}
