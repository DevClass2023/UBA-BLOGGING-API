using AutoMapper;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BloggingSystem.Application.Queries.Author;

// Handler for retrieving all authors
public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorDto>>
{
    private readonly IUnitOfWork _uow; // Unit of Work for data access
    private readonly IMapper _mapper;  // Mapper for entity to DTO

    public GetAllAuthorsHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all author entities from the database
        var authors = await _uow.Authors.GetAllAsync();

        // Map the list of author entities to a list of AuthorDto objects 
        return _mapper.Map<List<AuthorDto>>(authors);
    }
}