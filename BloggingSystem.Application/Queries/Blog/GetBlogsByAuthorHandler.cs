using MediatR;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BloggingSystem.Application.Exceptions;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Domain.Interfaces;

namespace BloggingSystem.Application.Queries.Blog;

public class GetBlogsByAuthorHandler : IRequestHandler<GetBlogsByAuthorQuery, List<BlogDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetBlogsByAuthorHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<BlogDto>> Handle(GetBlogsByAuthorQuery request, CancellationToken cancellationToken)
    {
        var authorExists = await _uow.Authors.GetByIdAsync(request.AuthorId);
        if (authorExists == null)
        {
            throw new NotFoundException($"Author with ID {request.AuthorId} not found.");
        }

        var blogs = await _uow.Blogs.GetByAuthorIdAsync(request.AuthorId);
        return _mapper.Map<List<BlogDto>>(blogs);
    }
}