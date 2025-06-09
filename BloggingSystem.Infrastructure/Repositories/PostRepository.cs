using BloggingSystem.Domain.Entities;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloggingSystem.Infrastructure.Repositories;

// Handles data operations for the Post entity.
public class PostRepository : IPostRepository
{
    private readonly BloggingDbContext _context;

    public PostRepository(BloggingDbContext context)
    {
        _context = context;
    }

    // Adds a new post to the database context.
    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
    }

    // Retrieves a post by its unique ID.
    public async Task<Post?> GetByIdAsync(Guid id)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    // Retrieves all posts associated with a specific blog.
    public async Task<IEnumerable<Post>> GetPostsByBlogAsync(Guid blogId)
    {
        return await _context.Posts
            .Where(p => p.BlogId == blogId)
            .ToListAsync();
    }
}
