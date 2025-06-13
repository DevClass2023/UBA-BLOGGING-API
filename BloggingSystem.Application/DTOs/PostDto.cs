using System;

namespace BloggingSystem.Application.DTOs;

public class PostDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime DatePublished { get; set; }
    public Guid BlogId { get; set; }
}