
using AutoMapper; 
using BloggingSystem.Application.DTOs; 
using BloggingSystem.Domain.Interfaces; 
using MediatR; 
using System.Collections.Generic;
using System.Threading; 
using System.Threading.Tasks;

namespace BloggingSystem.Application.Queries.Blog;

// Handler for retrieving all blogs
public class GetAllBlogsHandler : IRequestHandler<GetAllBlogsQuery, List<BlogDto>>
{
    private readonly IUnitOfWork _uow; // Unit of Work for data access
    private readonly IMapper _mapper;  // Mapper for entity to DTO

    public GetAllBlogsHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<BlogDto>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all blog entities from the database
        var blogs = await _uow.Blogs.GetAllAsync();
        
        // Map the list of blog entities to a list of BlogDto objects and return them
        return _mapper.Map<List<BlogDto>>(blogs);
    }
}