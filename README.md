Blogging System API

Project Overview
Welcome to the Blogging System API! This project is a robust and scalable backend for a blogging platform, meticulously designed with modern architectural principles to ensure maintainability, testability, and flexibility. It provides core functionalities for managing authors, blogs, and posts.

Features
This API exposes endpoints for the following core functionalities:

Authors
Create a new author.
Retrieve an author by their unique ID.

Blogs
Create a new blog (associated with an author).
Retrieve a list of all blogs.
Retrieve all blogs belonging to a specific author.


Posts
Create a new post (associated with a blog).
Retrieve all posts belonging to a specific blog.

 Architecture - The Onion and Beyond
This project is carefully crafted following the Onion Architecture (also known as Ports and Adapters or Hexagonal Architecture) paradigm. This layered structure provides a clear separation of concerns, ensuring that the core business logic remains independent of infrastructure and UI concerns.

Why Onion Architecture?
Decoupling: Dependencies flow inwards. Outer layers depend on inner layers, but inner layers have no knowledge of outer layers. This means your domain logic isn't tied to your database (EF Core) or your API framework (ASP.NET Core).
Testability: The core business logic can be tested in isolation without needing a database or web server.
Maintainability: Changes in infrastructure (e.g., switching databases from SQLite to SQL Server) or presentation (e.g., building a different UI) have minimal impact on the core domain.
Scalability: Allows for easier scaling and evolution of individual components.
Core Concepts and Technologies Used
Within this Onion Architecture, several key concepts and libraries are leveraged:

Domain Layer

Entities: Represents the core business objects (Author, Blog, Post). These are pure C# objects with no external dependencies, enforcing domain rules.
Interfaces: Defines contracts (ports) for external services like repositories (IAuthorRepository, IBlogRepository, IPostRepository). This allows infrastructure implementations to be swapped out without affecting the domain or application layers.

Application Layer.

CQRS (Command Query Responsibility Segregation): Separates read (Query) and write (Command) operations.
Commands -  Represent actions that change the state of the application (e.g., CreateAuthorCommand). Handled by IRequestHandler implementations.

Queries -  Represent requests to retrieve data without altering state (e.g., GetAuthorByIdQuery). Handled by IRequestHandler implementations.

MediatR -  An in-process messaging library that acts as a simple mediator pattern implementation. It orchestrates the flow of Commands and Queries to their respective Handlers, decoupling the sender from the receiver.

DTOs (Data Transfer Objects) - Simple objects used to transfer data between the application and presentation layers, ensuring no direct exposure of domain entities.

AutoMapper - Simplifies the mapping between DTOs and domain entities (and vice-versa), reducing boilerplate code.

FluentValidation - A powerful validation library used to define validation rules for Commands and Queries, ensuring input data meets business requirements before processing.

Infrastructure Layer

Entity Framework Core (EF Core): Microsoft's recommended Object-Relational Mapper (ORM). It facilitates database interactions, mapping C# objects to database tables (BloggingDbContext).

Repositories -  Concrete implementations of the interfaces defined in the Domain layer (AuthorRepository, BlogRepository, PostRepository). They encapsulate data access logic for specific entities.

Unit of Work - (IUnitOfWork, UnitOfWork) Coordinates operations across multiple repositories, ensuring that a set of changes are committed as a single transaction (all or nothing). This maintains data consistency.

Dependency Injection (DI) - Managed by the built-in .NET Core DI container. Services are registered here (InfrastructureServiceRegistration.cs) and resolved throughout the application, promoting loose coupling and testability.


API Layer (Presentation Layer)

ASP.NET Core Web API - The entry point of the application, exposing RESTful endpoints.
Controllers - Handle incoming HTTP requests, translate them into MediatR commands/queries, send them to the Application layer, and return appropriate HTTP responses.

Dependency Injection (DI): Configured in Program.cs and ServiceCollectionExtensions.cs to set up the application's entire service graph.


📂 Project Structure
BloggingSystem/
├── BloggingSystem.sln             // Visual code Solution File
│
├── BloggingSystem.Domain/         // Core business logic, entities, and interfaces
│   ├── Entities/                  // Author, Blog, Post, BaseEntity
│   ├── Interfaces/                // IAuthorRepository, IBlogRepository, IPostRepository, IUnitOfWork
│  
│
├── BloggingSystem.Application/    // Application-specific business rules, DTOs, commands, queries, and orchestration
│   ├── DTOs/                      // AuthorDto, BlogDto, PostDto, Create*Dtos
│   ├── Commands/                  // Author, Blog, Post subfolders with Command, Handler, Validator
│   ├── Queries/                   // Author, Blog, Post subfolders with Query, Handler
│   ├── Profiles/                  // AutoMapper mapping profiles (AuthorProfile, BlogProfile, PostProfile)
│   ├── Exceptions/                // Application-specific exceptions (NotFoundException, ValidationException)
│   └── AssemblyReference.cs       // Marker for assembly scanning
│
├── BloggingSystem.Infrastructure/ // Implementation of Domain interfaces, external services (e.g., database)
│   ├── Persistence/               // BloggingDbContext (EF Core context)
│   ├── Repositories/              // Concrete repository implementations (AuthorRepository, BlogRepository, PostRepository)
│   ├── UnitOfWork/                // UnitOfWork implementation
│   ├── DependencyInjection/       // InfrastructureServiceRegistration (for DI setup)
│   └── Migrations/                // Entity Framework Core database migrations being deleted but u can run it back later 
│
└── BloggingSystem.API/            // The presentation layer (ASP.NET Core Web API)
    ├── Controllers/               // API endpoints (AuthorsController, BlogsController, PostsController)
    ├── Extensions/                // Custom extension methods for service registration
    ├── Program.cs                 // Application entry point, hosts web server
    ├── appsettings.json           // Base application settings (e.g., connection string)
    └── appsettings.Development.json // Environment-specific settings


Prerequisites
.NET SDK 8.0 or later: Download and install from dotnet.microsoft.com/download.
dotnet-ef global tool: Essential for Entity Framework Core migrations.

Git: For cloning the repository.
Code Editor: Visual Studio Code.
Installation & Setup
Clone the repository
Open your terminal or command prompt and run:



git clone https://github.com/DevClass2023/UBA-BLOGGING-API.git
cd UBA-BLOGGING-API

Restore NuGet packages -
Navigate to the solution's root directory (BloggingSystem/ where BloggingSystem.sln is located) and run:


Database Setup (SQLite - Default Configuration):
This project is pre-configured to use SQLite as its default database provider, making it easy to get started without needing a separate database server. The BloggingSystem.db file will be created in your API project's output directory (e.g., BloggingSystem.API/bin/Debug/net8.0).


cd BloggingSystem.Infrastructure
Apply Database Migrations - This will create the SQLite database file and apply your schema for the project.


dotnet ef database update
If you need to create the initial migration first (e.g., starting fresh):


Navigate to the API project

cd ../BloggingSystem.API
Run the application

dotnet run

Why Minimal Comments?
You might notice that the project code contains minimal comments within the methods and classes themselves. This approach follows the principle of "Clean Code" and "Self-Documenting Code".

Readability -  We strive for well-structured code with meaningful variable names, method names, and clear class responsibilities so that the code is inherently understandable. The code itself becomes the primary source of truth for "what" it does.

Maintainability -  Comments can quickly become outdated as code evolves, leading to confusion and errors. By minimizing comments, we enforce a discipline of writing clearer code that doesn't need constant annotation.

