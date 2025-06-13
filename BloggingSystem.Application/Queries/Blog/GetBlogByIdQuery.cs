using System;
using MediatR;
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Queries.Blog;

// Query to retrieve a single blog by its ID.
public class GetBlogByIdQuery : IRequest<BlogDto>
{
    public Guid Id { get; set; } // The unique identifier of the blog to retrieve.
}