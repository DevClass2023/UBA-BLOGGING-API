
using System;
using MediatR; 
using BloggingSystem.Application.DTOs.Author;

namespace BloggingSystem.Application.Queries.Author;

public class GetAuthorByIdQuery : IRequest<AuthorDto>
{
    // The unique identifier of the author to retrieve.
    public Guid Id { get; set; }
}