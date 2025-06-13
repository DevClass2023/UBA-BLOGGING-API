using BloggingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingSystem.Domain.Interfaces;

public interface IPostRepository
{
    // Changed return type to Task<Post?> to allow for null if not found
    Task<Post?> GetByIdAsync(Guid id);
    // Method to get posts by blog ID
    Task<IEnumerable<Post>> GetByBlogIdAsync(Guid blogId);
    Task AddAsync(Post post);
}