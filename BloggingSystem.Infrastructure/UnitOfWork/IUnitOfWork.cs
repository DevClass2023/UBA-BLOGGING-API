using BloggingSystem.Domain.Interfaces;

namespace BloggingSystem.Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IAuthorRepository Authors { get; }  // Access Author repository
    IBlogRepository Blogs { get; }      // Access Blog repository
    IPostRepository Posts { get; }      // Access Post repository

    Task<int> SaveChangesAsync();       // Save changes to the database
}

