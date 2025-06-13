using System;

namespace BloggingSystem.Application.DTOs;

public class AuthorDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}