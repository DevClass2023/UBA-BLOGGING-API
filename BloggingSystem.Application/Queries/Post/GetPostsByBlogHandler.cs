using AutoMapper; 
using BloggingSystem.Application.DTOs; 
using BloggingSystem.Domain.Interfaces; 
using MediatR; /
using System.Collections.Generic; /
using System.Threading; 
using System.Threading.Tasks; 


namespace BloggingSystem.Application.Queries.Post;

// Handler for retrieving posts associated with a specific blog
public class GetPostsByBlogHandler : IRequestHandler<GetPostsByBlogQuery, List<PostDto>>
{
    private readonly IUnitOfWork _uow;   // Abstraction for data access operations
    private readonly IMapper _mapper;    // Tool for mapping entities to DTOs

    public GetPostsByBlogHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> Handle(GetPostsByBlogQuery request, CancellationToken cancellationToken)
    {
        // Fetch all posts that belong to the specified BlogId using the Post repository
        var posts = await _uow.Posts.GetByBlogIdAsync(request.BlogId); 
        
        // Map the retrieved list of Post entities to a list of PostDto objects and return them
        return _mapper.Map<List<PostDto>>(posts);                     
    }
}