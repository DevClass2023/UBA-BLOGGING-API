using System;

namespace BloggingSystem.Application.DTOs;

public class CreatePostDto
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime DatePublished { get; set; }
    public Guid BlogId { get; set; }
}