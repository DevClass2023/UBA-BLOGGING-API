using System;

namespace BloggingSystem.Application.DTOs;

public class CreatePostDto
{
    public string Title { get; set; }          // Post title
    public string Content { get; set; }        // Post content/body
    public DateTime DatePublished { get; set; } // Date when the post is published
    public Guid BlogId { get; set; }            // ID of the blog this post belongs to
}
