using BloggingSystem.Application.Commands.Author;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Application.Queries.Author; 
using BloggingSystem.Application.Queries.Blog; 
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet] // Endpoint: GET /api/authors (List all authors)
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAuthors()
    {
      
        var query = new GetAllAuthorsQuery();
        var authors = await _mediator.Send(query);
        return Ok(authors);
    }

    [HttpGet("{id}")] // Endpoint: GET /api/authors/{id} (Get an author by ID)
    public async Task<ActionResult<AuthorDto>> GetAuthorById(Guid id)
    {
        var query = new GetAuthorByIdQuery { Id = id };
        var author = await _mediator.Send(query);
        if (author == null)
        {
            return NotFound();
        }
        return Ok(author);
    }

    [HttpPost] // Endpoint: POST /api/authors (Create a new author)
    public async Task<ActionResult<AuthorDto>> CreateAuthor([FromBody] CreateAuthorDto dto)
    {
        var command = new CreateAuthorCommand { Dto = dto };
        var resultId = await _mediator.Send(command); // Get the ID back from the command
        // Retrieve the created author to return the full DTO (optional, but good practice for CreatedAtAction)
        var createdAuthor = await _mediator.Send(new GetAuthorByIdQuery { Id = resultId });
        return CreatedAtAction(nameof(GetAuthorById), new { id = resultId }, createdAuthor);
    }

    [HttpGet("{authorId}/blogs")] // Endpoint: GET /api/authors/{authorId}/blogs (Get all blogs by an author)
    public async Task<ActionResult<IEnumerable<BlogDto>>> GetBlogsByAuthor(Guid authorId)
    {
        var query = new GetBlogsByAuthorQuery { AuthorId = authorId };
        var blogs = await _mediator.Send(query);
        return Ok(blogs);
    }
}