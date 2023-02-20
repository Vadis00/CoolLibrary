﻿namespace CoolLibrary.Common.DTO
{
    public class BookDto
    {
        public int? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Cover { get; set; } = null!;
        public string Content { get; set; } = null!;
        public decimal Rating { get; set; }
        public int ReviewsNumber { get; set; }
    }
}
