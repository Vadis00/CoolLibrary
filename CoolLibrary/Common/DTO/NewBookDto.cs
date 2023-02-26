using FluentValidation;
using System;

namespace CoolLibrary.Common.DTO
{
    public class NewBookDto
    {
        public int? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Cover { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Genre { get; set; } = null!;
    }

    public class NewBookDtoValidator : AbstractValidator<NewBookDto>
    {
        public NewBookDtoValidator()
        {
            RuleFor(x => x.Title).Length(1, 200);
            RuleFor(x => x.Author).Length(1, 100);
            RuleFor(x => x.Genre).Length(1, 100);
        }
    }
}