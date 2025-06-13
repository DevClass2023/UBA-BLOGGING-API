using System;
using MediatR;
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Commands.Post;

// Command to create a new post
public class CreatePostCommand : IRequest<Guid>
{
 
    public required CreatePostDto Dto { get; set; }
}