
using BloggingSystem.Domain.Entities;
using System; 

namespace BloggingSystem.Domain.Interfaces;

public interface IAuthorRepository
{
    Task<Author> GetByIdAsync(Guid id);
    Task<IEnumerable<Blog>> GetBlogsByAuthorAsync(Guid authorId);
    Task AddAsync(Author author);
    Task<IEnumerable<Author>> GetAllAsync(); 
   
}