
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Infrastructure.Persistence;
using BloggingSystem.Infrastructure.Repositories;
using BloggingSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite; 

namespace BloggingSystem.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
   
    // Registers infrastructure services including DbContext, repositories, and unit of work.
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure EF Core to use a database provider.
        services.AddDbContext<BloggingDbContext>(options =>
        {
            // The following line is commented out to disable SQL Server configuration.
            // options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            // This line configures EF Core to use SQLite, reading the connection string
            // from 'DefaultConnection' in your appsettings.json (e.g., "DataSource=BloggingSystem.db").
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });

        // Register repositories
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IPostRepository, PostRepository>();

        // Register Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}