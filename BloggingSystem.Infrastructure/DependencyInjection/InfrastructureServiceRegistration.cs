using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Infrastructure.Persistence;
using BloggingSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite; 

namespace BloggingSystem.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure EF Core to use SQLite
        services.AddDbContext<BloggingDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });

        // Register Repositories
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IPostRepository, PostRepository>();

        // Register Unit of Work
        services.AddScoped<IUnitOfWork, BloggingSystem.Infrastructure.UnitOfWork.UnitOfWork>();

        return services;
    }
}