using AutoMapper;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Application.Exceptions;
using BloggingSystem.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BloggingSystem.Application.Queries.Author;

public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAuthorByIdHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _uow.Authors.GetByIdAsync(request.Id);

        if (author == null)
            throw new NotFoundException($"Author with Id: {request.Id} not found.");

        return _mapper.Map<AuthorDto>(author);
    }
}