
using FluentValidation;
using BloggingSystem.Application.DTOs; 
using System; 

namespace BloggingSystem.Application.Commands.Blog; 

public class CreateBlogValidator : AbstractValidator<CreateBlogDto> 
{
    public CreateBlogValidator()
    {
        // Rules for CreateBlogDto properties
        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("Blog name is required.");

        RuleFor(b => b.Url)
            .NotEmpty().WithMessage("Blog URL is required.")
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
            .WithMessage("A valid URL is required for the blog.");

        // Assuming AuthorId is required for blog creation
        RuleFor(b => b.AuthorId)
            .NotEmpty().WithMessage("Author ID is required for the blog.");
    }
}