using BloggingSystem.Domain.Entities;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Infrastructure.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly BloggingDbContext _context;

    public BlogRepository(BloggingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Blog blog)
    {
        await _context.Blogs.AddAsync(blog);
    }

    public async Task<Blog?> GetByIdAsync(Guid id)
    {
        return await _context.Blogs
            .Include(b => b.Posts)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<Blog>> GetAllAsync()
    {
        return await _context.Blogs.ToListAsync();
    }

    public async Task<IEnumerable<Blog>> GetByAuthorIdAsync(Guid authorId)
    {
        return await _context.Blogs.Where(b => b.AuthorId == authorId)
                                   .ToListAsync();
    }
}