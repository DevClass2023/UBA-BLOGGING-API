using System; 

namespace BloggingSystem.Domain.Interfaces;
public interface IBlogRepository
{
    Task<Blog> GetByIdAsync(Guid id);
    Task<IEnumerable<Blog>> GetAllAsync();
    Task AddAsync(Blog blog);
    Task<IEnumerable<Blog>> GetByAuthorIdAsync(Guid authorId); 
}