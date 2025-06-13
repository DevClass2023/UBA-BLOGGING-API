using AutoMapper;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Application.Exceptions; // Assuming you have a NotFoundException
using BloggingSystem.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BloggingSystem.Application.Queries.Post;

public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, PostDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetPostByIdHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        // Retrieve the post from the database using the Unit of Work
        var post = await _uow.Posts.GetByIdAsync(request.Id);

        // If no post is found, throw a NotFoundException
        if (post == null)
            throw new NotFoundException($"Post with Id: {request.Id} not found.");

        // Map the found Post entity to a PostDto and return it
        return _mapper.Map<PostDto>(post);
    }
}