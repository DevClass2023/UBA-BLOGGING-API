using BloggingSystem.Domain.Entities;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly BloggingDbContext _context;

    public PostRepository(BloggingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
    }

    public async Task<Post?> GetByIdAsync(Guid id)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Post>> GetByBlogIdAsync(Guid blogId)
    {
        return await _context.Posts
            .Where(p => p.BlogId == blogId)
            .ToListAsync();
    }
}