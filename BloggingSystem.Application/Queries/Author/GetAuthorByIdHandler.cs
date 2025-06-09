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
        // Retrieve the author from the database using the Unit of Work
        var author = await _uow.Authors.GetByIdAsync(request.Id);
        
        // If no author is found, throw a NotFoundException
        if (author == null) 
            throw new NotFoundException($"Author with Id: {request.Id} not found.");
        
        // Map the found Author entity to an AuthorDto and return it
        return _mapper.Map<AuthorDto>(author);
    }
}