using AutoMapper;
using BloggingSystem.Application.DTOs.Post;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Domain.Entities;
using MediatR;
using System;
using System.Threading; 
using System.Threading.Tasks; 

using BloggingSystem.Application.Commands.Post; 

namespace BloggingSystem.Application.Commands.Post;

public class CreatePostHandler : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IUnitOfWork _uow;    // Data access
    private readonly IMapper _mapper;     // DTO to entity mapper

    public CreatePostHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Post>(request.Dto);   // Map DTO to Post entity
        await _uow.Posts.AddAsync(entity);             // Add post to repository
        await _uow.SaveChangesAsync();                  // Commit changes
        return entity.Id;                               // Return new post ID
    }
}