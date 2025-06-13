using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR; // Ensure this using directive is present
using AutoMapper; // Ensure this using directive is present
using FluentValidation; // Ensure this using directive is present for AddValidatorsFromAssembly
using BloggingSystem.Application; // Ensure this using directive is present for AssemblyReference
using BloggingSystem.Infrastructure.DependencyInjection; // Ensure this using directive is present

namespace BloggingSystem.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // FIX FOR CS1061:
        // For MediatR v12+ (and often v10+), the simplest and most robust way
        // to register services from an assembly is to pass the assembly directly.
        // This implicitly handles the registration of all IRequest and IRequestHandler implementations.
        services.AddMediatR(typeof(Application.AssemblyReference).Assembly);

        // Registers AutoMapper: Scans the BloggingSystem.Application assembly for Profile classes
        services.AddAutoMapper(typeof(Application.AssemblyReference).Assembly);

        // Registers FluentValidation: Scans the BloggingSystem.Application assembly for AbstractValidator classes
        // Ensure you have the 'FluentValidation.DependencyInjection.Extensions' NuGet package installed in your API project.
        services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);

        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Delegates to the static extension method defined in your BloggingSystem.Infrastructure project.
        return InfrastructureServiceRegistration.AddInfrastructureServices(services, configuration);
    }
}