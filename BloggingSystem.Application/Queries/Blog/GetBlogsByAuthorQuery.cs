
using MediatR;
using BloggingSystem.Application.DTOs;
using System;
using System.Collections.Generic;

namespace BloggingSystem.Application.Queries.Blog
{
    public class GetBlogsByAuthorQuery : IRequest<List<BlogDto>>
    {
        public Guid AuthorId { get; set; }
    }
}