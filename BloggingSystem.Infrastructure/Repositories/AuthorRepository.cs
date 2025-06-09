using BloggingSystem.Domain.Entities;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloggingSystem.Infrastructure.Repositories;

// Handles data operations for the Author entity.
public class AuthorRepository : IAuthorRepository
{
    private readonly BloggingDbContext _context;

    public AuthorRepository(BloggingDbContext context)
    {
        _context = context;
    }

    // Adds a new author to the database context.
    public async Task AddAsync(Author author)
    {
        await _context.Authors.AddAsync(author);
    }

    // Retrieves all authors including their blogs.
    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _context.Authors.Include(a => a.Blogs).ToListAsync();
    }

    // Retrieves a single author by ID, including their blogs.
    public async Task<Author> GetByIdAsync(Guid id)
    {
        return await _context.Authors
            .Include(a => a.Blogs)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
