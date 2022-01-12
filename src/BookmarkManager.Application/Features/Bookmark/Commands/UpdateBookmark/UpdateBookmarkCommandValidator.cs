using FluentValidation;

namespace BookmarkManager.Application.Features
{
    public class UpdateBookmarkCommandValidator: AbstractValidator<UpdateBookmarkCommand>
    {
        public UpdateBookmarkCommandValidator()
        {
            RuleFor(bookmark => bookmark.Id).NotEqual(0).WithMessage("`Id` must be greater than zero");
            RuleFor(bookmark => bookmark.Location).NotEmpty().WithMessage("`Location` is required");
            RuleFor(bookmark => bookmark.Title).NotEmpty().WithMessage("`Title` is required");
        }
    }
}
