
using FluentValidation;
using BloggingSystem.Application.DTOs.Author;
using System;
using MediatR;
using AutoMapper;


// Validator for CreateAuthorCommand, specifically validating its inner CreateAuthorDto
public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
{ 
    public CreateAuthorValidator()
    {
        // RuleFor the DTO property within the command
        RuleFor(x => x.Dto).NotNull().WithMessage("Author data (DTO) is required.");

        // Apply rules to the DTO's properties
        RuleFor(x => x.Dto.Name)
            .NotEmpty().WithMessage("Name is required."); // Name must not be empty

        RuleFor(x => x.Dto.Email)
            .NotEmpty().WithMessage("Email is required.") // Email must not be empty
            .EmailAddress().WithMessage("A valid email address is required."); // Email must be in a valid format
    }
}