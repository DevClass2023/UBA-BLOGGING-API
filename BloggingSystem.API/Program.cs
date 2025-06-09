

using BloggingSystem.API.Extensions; // Import your custom extension methods
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models; // For Swagger documentation info

var builder = WebApplication.CreateBuilder(args);

// --- Configure Services ---

// 1. Add API Controllers and related services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Required for Swagger/OpenAPI generation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BloggingSystem API", Version = "v1", Description = "A simple API for managing authors, blogs, and posts." });
});

// 2. Register Application Layer services using your custom extension method
builder.Services.AddApplicationServices();

// 3. Register Infrastructure Layer services using your custom extension method
builder.Services.AddInfrastructureServices(builder.Configuration);

// --- Build the Application ---
var app = builder.Build();

// --- Configure HTTP Request Pipeline (Middleware) ---

// 1. Enable Swagger UI only in Development environment for API documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BloggingSystem API v1");
        // Makes Swagger UI accessible at the root URL (e.g., https://localhost:7000/ instead of /swagger)
        c.RoutePrefix = string.Empty;
    });
}

// 2. Redirect HTTP requests to HTTPS (security best practice)
app.UseHttpsRedirection();

// 3. Enable routing middleware
app.UseRouting();

// 4. Enable authorization middleware
app.UseAuthorization();

// 5. Map controllers to handle incoming API requests
app.MapControllers();

// --- Run the Application ---
app.Run();