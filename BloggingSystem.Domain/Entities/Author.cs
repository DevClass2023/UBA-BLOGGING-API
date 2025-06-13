using System;
using System.Collections.Generic;

namespace BloggingSystem.Domain.Entities;

// Represents the Author of blogs
public class Author : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Navigation property to one author has many blogs
    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}