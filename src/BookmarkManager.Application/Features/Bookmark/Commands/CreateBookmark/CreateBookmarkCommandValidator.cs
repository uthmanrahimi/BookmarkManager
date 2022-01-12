using FluentValidation;

namespace BookmarkManager.Application.Features
{
    public class CreateBookmarkCommandValidator: AbstractValidator<CreateBookmarkCommand>
    {
        public CreateBookmarkCommandValidator()
        {
            RuleFor(bookmark => bookmark.OwnerId).GreaterThan(0).WithMessage("OwnerId must be greate than zero");
            RuleFor(bookmark => bookmark.Location).NotEmpty().WithMessage("Location is required");
            RuleFor(bookmark => bookmark.Title).NotEmpty().WithMessage("Title is required");
        }
    }
}
