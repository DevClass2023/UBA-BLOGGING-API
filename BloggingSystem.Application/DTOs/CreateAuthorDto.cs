using System;

namespace BloggingSystem.Application.DTOs;

public class CreateAuthorDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}