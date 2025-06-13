using System;

namespace BloggingSystem.Application.DTOs;

public class BlogDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public Guid AuthorId { get; set; }
}