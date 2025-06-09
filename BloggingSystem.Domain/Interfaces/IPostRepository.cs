
using BloggingSystem.Domain.Entities;
using System; 

namespace BloggingSystem.Domain.Interfaces;

public interface IPostRepository
{
    Task<Post> GetByIdAsync(Guid id); 
    Task<IEnumerable<Post>> GetPostsByBlogAsync(Guid blogId);
    Task AddAsync(Post post);
  
}