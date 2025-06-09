using AutoMapper;
using BloggingSystem.Application.DTOs.Blog;
using BloggingSystem.Domain.Entities;
using BloggingSystem.Domain.Interfaces;
using MediatR;
using System;

// Handler for creating a new blog
public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, Guid>
{
    private readonly IUnitOfWork _uow; // Unit of Work for data access
    private readonly IMapper _mapper;  // AutoMapper for mapping DTO to entity

    public CreateBlogHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Blog>(request.Dto);     // Map DTO to Blog entity
        await _uow.Blogs.AddAsync(entity);                // Add blog to database
        await _uow.SaveChangesAsync();                    // Save changes
        return entity.Id;                                 // Return the new blog ID
    }
}
