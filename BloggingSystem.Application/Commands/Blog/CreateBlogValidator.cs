using FluentValidation;
using BloggingSystem.Application.DTOs.Blog;
using System;
using MediatR;
using AutoMapper;
public class CreateBlogValidator : AbstractValidator<CreateBlogDto>
{
    public CreateBlogValidator()
    {
        RuleFor(b => b.Name).NotEmpty();
        RuleFor(b => b.Url).NotEmpty().Must(url => Uri.TryCreate(url, UriKind.Absolute, out _));
    }
}