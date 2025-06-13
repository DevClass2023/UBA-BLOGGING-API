using System;
using MediatR;
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Queries.Author;

public class GetAuthorByIdQuery : IRequest<AuthorDto>
{
    public Guid Id { get; set; } 
}