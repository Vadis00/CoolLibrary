using FluentValidation;

namespace CoolLibrary.Common.DTO
{
    public class NewReviewDto
    {
        public string Message { get; set; } = null!;
        public string Reviewer { get; set; } = null!;
    }

    public class NewReviewDtoValidator : AbstractValidator<NewReviewDto>
    {
        public NewReviewDtoValidator()
        {
            RuleFor(x => x.Message).Length(5, 1000);
            RuleFor(x => x.Reviewer).Length(5, 100);
        }
    }
}