using FluentValidation;

namespace BookmarkManager.Application.Features
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(category => category.Title).NotEmpty().WithMessage("`Title` is required");
        }
    }
}
