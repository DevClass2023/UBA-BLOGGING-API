using System;

namespace BloggingSystem.Domain.Entities;

// Represents a Blog written by an Author
public class Blog : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

   // Foreign key to Author
    public Guid AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    // Navigation property for related Posts
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}




