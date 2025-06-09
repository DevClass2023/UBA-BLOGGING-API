using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Infrastructure.Persistence;
using BloggingSystem.Infrastructure.Repositories;

namespace BloggingSystem.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly BloggingDbContext _context;

    public IAuthorRepository Authors { get; private set; }  // Author repository
    public IBlogRepository Blogs { get; private set; }      // Blog repository
    public IPostRepository Posts { get; private set; }      // Post repository

    public UnitOfWork(BloggingDbContext context)
    {
        _context = context;
        Authors = new AuthorRepository(_context);  // Initialize Author repo
        Blogs = new BlogRepository(_context);      // Initialize Blog repo
        Posts = new PostRepository(_context);      // Initialize Post repo
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();  // Commit changes
    }

    public void Dispose()
    {
        _context.Dispose();  // Dispose context
    }
}
