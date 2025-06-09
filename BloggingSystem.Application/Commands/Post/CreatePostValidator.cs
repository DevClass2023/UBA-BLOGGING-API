using FluentValidation;
using BloggingSystem.Application.DTOs.Post;

namespace BloggingSystem.Application.Commands.Post;
public class CreatePostValidator : AbstractValidator<CreatePostDto>
{
    public CreatePostValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("Post title is required.");    // Custom message for Title

        RuleFor(p => p.Content)
            .NotEmpty().WithMessage("Post content is required.");  // Custom message for Content
    }
}
