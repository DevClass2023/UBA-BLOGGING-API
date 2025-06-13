using BloggingSystem.Application.Commands.Post;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Application.Queries.Post; // Now includes GetPostByIdQuery
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

    [HttpGet("{id}")] // Endpoint: GET /api/posts/{id} (Get a post by ID)
    public async Task<ActionResult<PostDto>> GetPostById(Guid id)
    {
      
        var query = new GetPostByIdQuery { Id = id };
        var post = await _mediator.Send(query);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    [HttpPost] 
    public async Task<ActionResult<PostDto>> CreatePost([FromBody] CreatePostDto dto)
    {
        var command = new CreatePostCommand { Dto = dto };
        var resultId = await _mediator.Send(command); // Get the ID back from the command
        // Retrieve the created post to return the full DTO
        var createdPost = await _mediator.Send(new GetPostByIdQuery { Id = resultId });
        return CreatedAtAction(nameof(GetPostById), new { id = resultId }, createdPost);
    }

    [HttpGet("byBlog/{blogId}")] 
    public async Task<ActionResult<IEnumerable<PostDto>>> GetPostsByBlog(Guid blogId)
    {
        var query = new GetPostsByBlogQuery { BlogId = blogId };
        var posts = await _mediator.Send(query);
        return Ok(posts);
    }
}