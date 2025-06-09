using FluentValidation;
using BloggingSystem.Application.DTOs;
using System;
using MediatR;


namespace BloggingSystem.Application.Commands.Blog;

public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, Guid>
{
    private readonly IUnitOfWork _uow;     // Data access abstraction
    private readonly IMapper _mapper;      // Maps DTO to entity

    public CreateBlogHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Blog>(request.Dto);   // Map DTO to Blog entity
        await _uow.Blogs.AddAsync(entity);             // Add blog to DB
        await _uow.SaveChangesAsync();                 // Commit changes
        return entity.Id;                              // Return new blog ID
    }
}
