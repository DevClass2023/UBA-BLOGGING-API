using AutoMapper;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BloggingSystem.Application.Queries.Blog;

public class GetAllBlogsHandler : IRequestHandler<GetAllBlogsQuery, List<BlogDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllBlogsHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<BlogDto>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _uow.Blogs.GetAllAsync();
        return _mapper.Map<List<BlogDto>>(blogs);
    }
}