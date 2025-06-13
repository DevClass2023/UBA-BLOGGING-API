using System;
using MediatR;
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Queries.Post;

// Query to retrieve a single post by its ID.
public class GetPostByIdQuery : IRequest<PostDto>
{
    public Guid Id { get; set; } // The unique identifier of the post to retrieve.
}