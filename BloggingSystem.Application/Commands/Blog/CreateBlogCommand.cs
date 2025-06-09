using BloggingSystem.Application.DTOs;
using MediatR;

namespace BloggingSystem.Application.Commands.Blog;
// Command to create a new blog
public class CreateBlogCommand : IRequest<Guid> 
{
    public CreateBlogDto Dto { get; set; } // Data needed to create the blog
}

