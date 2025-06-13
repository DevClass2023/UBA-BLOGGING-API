using AutoMapper;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BloggingSystem.Application.Queries.Post;

public class GetPostsByBlogHandler : IRequestHandler<GetPostsByBlogQuery, List<PostDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetPostsByBlogHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> Handle(GetPostsByBlogQuery request, CancellationToken cancellationToken)
    {
        var posts = await _uow.Posts.GetByBlogIdAsync(request.BlogId);
        return _mapper.Map<List<PostDto>>(posts);
    }
}