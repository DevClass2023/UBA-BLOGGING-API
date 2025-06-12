
using System; 
using MediatR; 
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Commands.Author;

// Command to create a new author
public class CreateAuthorCommand : IRequest<Guid> // Returns the ID (Guid) of the created author
{
    public CreateAuthorDto Dto { get; set; } = new CreateAuthorDto(); // Data needed to create the author
}