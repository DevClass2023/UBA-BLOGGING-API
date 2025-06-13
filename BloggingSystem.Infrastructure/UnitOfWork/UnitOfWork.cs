using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Infrastructure.Persistence;
using BloggingSystem.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace BloggingSystem.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly BloggingDbContext _dbContext;

   
    private IAuthorRepository? _authorRepository;
    private IBlogRepository? _blogRepository;
    private IPostRepository? _postRepository;

    public UnitOfWork(BloggingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Lazy initialization of repositories
    public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(_dbContext);
    public IBlogRepository Blogs => _blogRepository ??= new BlogRepository(_dbContext);
    public IPostRepository Posts => _postRepository ??= new PostRepository(_dbContext);

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this); 
    }
}