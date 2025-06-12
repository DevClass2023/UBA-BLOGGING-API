
using System; 
using MediatR; 
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Commands.Post;

// Command to create a new post
public class CreatePostCommand : IRequest<Guid>
{
    public CreatePostDto Dto { get; set; } = new CreatePostDto(); // Post data
}