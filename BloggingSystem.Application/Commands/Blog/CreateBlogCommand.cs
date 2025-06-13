using System;
using MediatR;
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Commands.Blog;

// Command to create a new blog
public class CreateBlogCommand : IRequest<Guid>
{
    public required CreateBlogDto Dto { get; set; }
}