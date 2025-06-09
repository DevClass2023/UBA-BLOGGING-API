
using BloggingSystem.Application.Commands.Author;
using BloggingSystem.Application.Queries.Author;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    // Creates a new author.
    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAuthorById), new { id = result.Id }, result);
    }

 
    // Retrieves an author by their ID.
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorById(Guid id)
    {
        var query = new GetAuthorByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}