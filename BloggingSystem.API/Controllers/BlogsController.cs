
using BloggingSystem.Application.Commands.Blog;
using BloggingSystem.Application.Queries.Blog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloggingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Creates a new blog.
    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command)
    {
        var result = await _mediator.Send(command);
     
        return CreatedAtAction(nameof(GetAllBlogs), new { id = result.Id }, result);
    }

    // Retrieves all blogs.
    [HttpGet]
    public async Task<IActionResult> GetAllBlogs()
    {
        var result = await _mediator.Send(new GetAllBlogsQuery());
        return Ok(result);
    }

    // Retrieves all blogs associated with a specific author.
    [HttpGet("by-author/{authorId}")]
    public async Task<IActionResult> GetBlogsByAuthor(Guid authorId)
    {
        var query = new GetBlogsByAuthorQuery(authorId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}