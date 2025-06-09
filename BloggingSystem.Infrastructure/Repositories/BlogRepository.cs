using BloggingSystem.Domain.Entities;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloggingSystem.Infrastructure.Repositories;

// Handles data operations for the Blog entity.
public class BlogRepository : IBlogRepository
{
    private readonly BloggingDbContext _context;

    public BlogRepository(BloggingDbContext context)
    {
        _context = context;
    }

    // Adds a new blog to the database context.
    public async Task AddAsync(Blog blog)
    {
        await _context.Blogs.AddAsync(blog);
    }

    // Retrieves a blog by ID, including its related posts.
    public async Task<Blog?> GetByIdAsync(Guid id)
    {
        return await _context.Blogs
            .Include(b => b.Posts)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    // Retrieves all blogs.
    public async Task<IEnumerable<Blog>> GetAllAsync()
    {
        return await _context.Blogs.ToListAsync();
    }


    public async Task<IEnumerable<Blog>> GetByAuthorIdAsync(Guid authorId)
        {
        return await _dbContext.Blogs.Where(b => b.AuthorId == authorId)
                                   .ToListAsync();
        }    
}
