
using System;
using System.Threading.Tasks;
using BloggingSystem.Application.Commands.Post;
using BloggingSystem.Application.Queries.Post;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloggingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // Creates a new post and associates it with a blog.
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetPostsByBlog), new { blogId = result.BlogId }, result);
    }

    
    // Retrieves all posts belonging to a specific blog.
    [HttpGet("by-blog/{blogId}")]
    public async Task<IActionResult> GetPostsByBlog(Guid blogId)
    {
        var query = new GetPostsByBlogQuery(blogId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}