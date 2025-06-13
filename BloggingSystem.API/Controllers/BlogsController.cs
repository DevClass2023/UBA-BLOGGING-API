using BloggingSystem.Application.Commands.Blog;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Application.Queries.Blog; 
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

    [HttpGet] // Endpoint: GET /api/blogs (List all blogs)
    public async Task<ActionResult<IEnumerable<BlogDto>>> GetAllBlogs()
    {
        var query = new GetAllBlogsQuery();
        var blogs = await _mediator.Send(query);
        return Ok(blogs);
    }

    [HttpGet("{id}")] // Endpoint: GET /api/blogs/{id} (Get a blog by ID)
    public async Task<ActionResult<BlogDto>> GetBlogById(Guid id)
    {
        // FIX: Correctly instantiate GetBlogByIdQuery
        var query = new GetBlogByIdQuery { Id = id };
        var blog = await _mediator.Send(query);
        if (blog == null)
        {
            return NotFound();
        }
        return Ok(blog);
    }

    [HttpPost] // Endpoint: POST /api/blogs (Create a new blog)
    public async Task<ActionResult<BlogDto>> CreateBlog([FromBody] CreateBlogDto dto)
    {
        var command = new CreateBlogCommand { Dto = dto };
        var resultId = await _mediator.Send(command); // Get the ID back from the command
        // Retrieve the created blog to return the full DTO
        var createdBlog = await _mediator.Send(new GetBlogByIdQuery { Id = resultId });
        return CreatedAtAction(nameof(GetBlogById), new { id = resultId }, createdBlog);
    }

    [HttpGet("byAuthor/{authorId}")] // Endpoint: GET /api/blogs/byAuthor/{authorId} (Get blogs belonging to an author)
    public async Task<ActionResult<IEnumerable<BlogDto>>> GetBlogsByAuthor(Guid authorId)
    {
        var query = new GetBlogsByAuthorQuery { AuthorId = authorId };
        var blogs = await _mediator.Send(query);
        return Ok(blogs);
    }
}