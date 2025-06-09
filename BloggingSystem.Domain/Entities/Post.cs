using System;


namespace BloggingSystem.Domain.Entities;
// Represents a blog post under a Blog
public class Post : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime DatePublished { get; set; }

   // Foreign key to Blog
    public Guid BlogId { get; set; }

    // Navigation property of each post belongs to a blog
    public Blog Blog { get; set; } = null!;
}





