using System;
using MediatR;
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Commands.Author;

// Command to create a new author
public class CreateAuthorCommand : IRequest<Guid>
{

    public required CreateAuthorDto Dto { get; set; }
}