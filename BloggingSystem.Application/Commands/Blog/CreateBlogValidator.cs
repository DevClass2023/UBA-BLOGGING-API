using FluentValidation;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Application.Commands.Author; 

namespace BloggingSystem.Application.Commands.Author;

public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorValidator()
    {
        RuleFor(x => x.Dto).NotNull().WithMessage("Author data (DTO) is required.");

        RuleFor(x => x.Dto.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Dto.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");
    }
}