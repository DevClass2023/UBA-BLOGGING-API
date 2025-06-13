using System;
using MediatR;
using System.Collections.Generic;
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Queries.Post;

public class GetPostsByBlogQuery : IRequest<List<PostDto>>
{
    public Guid BlogId { get; set; } // Property for the BlogId
}