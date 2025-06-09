using AutoMapper; 
using BloggingSystem.Domain.Entities; 
using BloggingSystem.Application.DTOs; 

namespace BloggingSystem.Application.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        // Define mapping from Post entity to PostDto
        // This is typically used when querying data to expose to the API consumer.
        CreateMap<Post, PostDto>();

        // Define mapping from CreatePostDto to Post entit
        CreateMap<CreatePostDto, Post>();
    }
}