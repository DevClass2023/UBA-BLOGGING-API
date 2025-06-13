using MediatR;
using System.Collections.Generic;
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Queries.Author;

// Query to retrieve all authors
public class GetAllAuthorsQuery : IRequest<List<AuthorDto>>
{

}