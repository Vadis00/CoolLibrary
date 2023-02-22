using CoolLibrary.Common.Entities;
using FluentValidation;

namespace CoolLibrary.Common.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public string Reviewer { get; set; } = null!;
    }
}