using FluentValidation;

namespace BookmarkManager.Application.Features
{
    public class CreateBookmarkCommandV2Validator: AbstractValidator<CreateBookmarkCommand>
    {
        public CreateBookmarkCommandV2Validator()
        {
            RuleFor(bookmark => bookmark.OwnerId).GreaterThan(0).WithMessage("OwnerId must be greate than zero");
            RuleFor(bookmark => bookmark.Location).NotEmpty().WithMessage("Location is required");
            RuleFor(bookmark => bookmark.Title).NotEmpty().WithMessage("Title is required");
        }
    }
}
