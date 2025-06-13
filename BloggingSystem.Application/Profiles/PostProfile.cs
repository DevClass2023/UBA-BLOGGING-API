using AutoMapper; 
using BloggingSystem.Domain.Entities; 
using BloggingSystem.Application.DTOs; 

namespace BloggingSystem.Application.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        // Define mapping from Post entity to PostDto
        CreateMap<Post, PostDto>();

        // Define mapping from CreatePostDto to Post entit
        CreateMap<CreatePostDto, Post>();
    }
}


