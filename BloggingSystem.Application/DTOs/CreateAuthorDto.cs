using System;

namespace BloggingSystem.Application.DTOs;

public class CreateAuthorDto
{
    public string Name { get; set; }   // Author's name
    public string Email { get; set; }  // Author's email
}
