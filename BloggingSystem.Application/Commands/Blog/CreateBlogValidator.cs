using FluentValidation;
using BloggingSystem.Application.DTOs;
using System; 

namespace BloggingSystem.Application.Commands.Blog;

public class CreateBlogValidator : AbstractValidator<CreateBlogDto>
{
    public CreateBlogValidator()
    {
        RuleFor(b => b.Name).NotEmpty();
        RuleFor(b => b.Url).NotEmpty().Must(url => Uri.TryCreate(url, UriKind.Absolute, out _));
    }
}