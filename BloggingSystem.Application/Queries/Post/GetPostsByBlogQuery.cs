
using System; 
using MediatR; 
using System.Collections.Generic; 
using BloggingSystem.Application.DTOs.Post; 

namespace BloggingSystem.Application.Queries.Post;

public class GetPostsByBlogQuery : IRequest<List<PostDto>>
{
    // The unique identifier (ID) of the blog for which to fetch posts.
    public Guid BlogId { get; set; }  
}