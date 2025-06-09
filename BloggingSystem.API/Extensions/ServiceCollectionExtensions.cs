
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
using FluentValidation;
using BloggingSystem.Application;
using BloggingSystem.Infrastructure.DependencyInjection;

namespace BloggingSystem.API.Extensions
{
   
    // Provides extension methods for IServiceCollection to encapsulate application and infrastructure service registrations.
    public static class ServiceCollectionExtensions
    {
     
        // Adds and configures services specific to the Application layer.
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                // Registers MediatR: Scans the BloggingSystem.Application assembly for IRequest/IRequestHandler implementations
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly))
                // Registers AutoMapper: Scans the BloggingSystem.Application assembly for Profile classes
                .AddAutoMapper(typeof(Application.AssemblyReference).Assembly)
                // Registers FluentValidation: Scans the BloggingSystem.Application assembly for AbstractValidator classes
                .AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);
        }

    
        // Adds and configures services specific to the Infrastructure layer.

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // static extension method defined in your BloggingSystem.Infrastructure project.
            return InfrastructureServiceRegistration.AddInfrastructureServices(services, configuration);
        }
    }
}