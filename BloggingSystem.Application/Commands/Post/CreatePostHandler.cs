using AutoMapper;
using MediatR;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Domain.Entities; 

namespace BloggingSystem.Application.Commands.Post;

public class CreatePostHandler : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreatePostHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
       
        var entity = _mapper.Map<BloggingSystem.Domain.Entities.Post>(request.Dto);

        await _uow.Posts.AddAsync(entity);
        await _uow.SaveChangesAsync();
        return entity.Id;
    }
}