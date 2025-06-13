using System;

namespace BloggingSystem.Application.DTOs;

public class CreateBlogDto
{

    public required string Name { get; set; }
    public required string Url { get; set; }
    public Guid AuthorId { get; set; }
}