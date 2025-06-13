using System;
using System.Threading.Tasks;

namespace BloggingSystem.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAuthorRepository Authors { get; }
    IBlogRepository Blogs { get; }
    IPostRepository Posts { get; }

    Task<int> SaveChangesAsync();
}