

using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 

using BloggingSystem.Domain.Entities; 

namespace BloggingSystem.Domain.Interfaces;

public interface IBlogRepository
{
    Task<Blog> GetByIdAsync(Guid id);
    Task<IEnumerable<Blog>> GetAllAsync();
    Task AddAsync(Blog blog);
    Task<IEnumerable<Blog>> GetByAuthorIdAsync(Guid authorId); 
}