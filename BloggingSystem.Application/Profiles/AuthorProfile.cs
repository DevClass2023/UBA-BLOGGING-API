using AutoMapper; 
using BloggingSystem.Domain.Entities; 
using BloggingSystem.Application.DTOs; 

namespace BloggingSystem.Application.Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        // Define mapping from Author entity to AuthorDto

        CreateMap<Author, AuthorDto>();

        // Define mapping from CreateAuthorDto to Author entity
        CreateMap<CreateAuthorDto, Author>();
    }
}