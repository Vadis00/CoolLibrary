using CoolLibrary.BLL.Exceptions;
using CoolLibrary.Common.Entities;
using FluentValidation;

namespace CoolLibrary.Common.DTO
{
    public class RatingDto
    {
        public decimal Score { get; set; }
    }

    public class RatingDtoValidator : AbstractValidator<RatingDto>
    {
        public RatingDtoValidator()
        {
            RuleFor(x => x.Score).InclusiveBetween(1, 5);
        }
    }
}