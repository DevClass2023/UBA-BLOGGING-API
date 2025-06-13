using BloggingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingSystem.Domain.Interfaces;

public interface IAuthorRepository
{
 
    Task<Author?> GetByIdAsync(Guid id);
    Task<IEnumerable<Author>> GetAllAsync();
    Task AddAsync(Author author);
    // Method to get blogs by author
    Task<IEnumerable<Blog>> GetBlogsByAuthorAsync(Guid authorId);
}