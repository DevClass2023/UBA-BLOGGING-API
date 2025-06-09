using System;

namespace BloggingSystem.Application.DTOs;

public class AuthorDto
{
    public Guid Id { get; set; } // Unique identifier for the author
    public string Name { get; set; } // Author's name
    public string Email { get; set; } // Author's email address
}