using System;

namespace BloggingSystem.Application.DTOs;


public class BlogDto
{
    public Guid Id { get; set; }        // Blog identifier
    public string Name { get; set; }    // Blog name
    public string Url { get; set; }     // Blog URL
    public Guid AuthorId { get; set; }  // ID of the author
}
