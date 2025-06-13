using BloggingSystem.Domain.Entities;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BloggingDbContext _context;

    public AuthorRepository(BloggingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Author author)
    {
        await _context.Authors.AddAsync(author);
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _context.Authors.Include(a => a.Blogs).ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(Guid id)
    {
        return await _context.Authors
            .Include(a => a.Blogs)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Blog>> GetBlogsByAuthorAsync(Guid authorId)
    {
        return await _context.Blogs
                             .Where(blog => blog.AuthorId == authorId)
                             .ToListAsync();
    }
}