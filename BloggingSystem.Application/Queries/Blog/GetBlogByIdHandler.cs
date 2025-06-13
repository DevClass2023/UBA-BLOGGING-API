using AutoMapper;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Application.Exceptions; 
using BloggingSystem.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BloggingSystem.Application.Queries.Blog;

public class GetBlogByIdHandler : IRequestHandler<GetBlogByIdQuery, BlogDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetBlogByIdHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<BlogDto> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        // Retrieve the blog from the database using the Unit of Work
        var blog = await _uow.Blogs.GetByIdAsync(request.Id);

        // If no blog is found, throw a NotFoundException
        if (blog == null)
            throw new NotFoundException($"Blog with Id: {request.Id} not found.");

        // Map the found Blog entity to a BlogDto and return it
        return _mapper.Map<BlogDto>(blog);
    }
}