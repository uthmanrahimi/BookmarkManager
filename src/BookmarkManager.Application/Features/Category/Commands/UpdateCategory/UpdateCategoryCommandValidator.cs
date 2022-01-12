
using FluentValidation;

namespace BookmarkManager.Application.Features
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(category => category.Id).GreaterThan(0).WithMessage("Id must be greater than zero");
            RuleFor(category => category.Title).NotEmpty().WithMessage("`Title` is required");
        }
    }
}
