using AutoMapper;
using MediatR;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Domain.Entities; 

namespace BloggingSystem.Application.Commands.Blog;

public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, Guid>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateBlogHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
      
        var entity = _mapper.Map<BloggingSystem.Domain.Entities.Blog>(request.Dto);

        await _uow.Blogs.AddAsync(entity);
        await _uow.SaveChangesAsync();
        return entity.Id;
    }
}