using AutoMapper; 
using BloggingSystem.Domain.Entities; 
using BloggingSystem.Application.DTOs; 

namespace BloggingSystem.Application.Profiles;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        // Define mapping from Blog entity to BlogDto
        CreateMap<Blog, BlogDto>();

        // Define mapping from CreateBlogDto to Blog entity
        // Used when receiving data from the API to create a new Blog entity for persistence.
        CreateMap<CreateBlogDto, Blog>();
    }
}