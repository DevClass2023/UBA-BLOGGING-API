using System.Collections.Generic;
using MediatR;
using BloggingSystem.Application.DTOs;

namespace BloggingSystem.Application.Queries.Blog;

public class GetAllBlogsQuery : IRequest<List<BlogDto>> { } 