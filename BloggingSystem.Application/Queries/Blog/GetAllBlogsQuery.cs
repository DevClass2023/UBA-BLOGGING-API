using System.Collections.Generic; 
using MediatR; 
using BloggingSystem.Application.DTOs; 

namespace BloggingSystem.Application.Queries.Blog;

// Query to retrieve all blogs
public class GetAllBlogsQuery : IRequest<List<BlogDto>> { 

}