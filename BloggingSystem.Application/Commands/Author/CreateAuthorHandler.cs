using AutoMapper; 
using MediatR;   
using BloggingSystem.Domain.Interfaces; 
using BloggingSystem.Domain.Entities; 
using BloggingSystem.Application.DTOs.Author;

namespace BloggingSystem.Application.Commands.Author;

public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, Guid> 
{
    private readonly IUnitOfWork _uow; // Unit of Work for data access
    private readonly IMapper _mapper;  // Mapper for DTO to entity

    public CreateAuthorHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        // Maps the DTO from the command to an Author entity
        var entity = _mapper.Map<Author>(request.Dto); 

        // Adds the new author entity to the database via the Author repository
        await _uow.Authors.AddAsync(entity);           
        
        // Saves all changes within the current unit of work to the database
        await _uow.SaveChangesAsync();                 
        
        // Returns the unique identifier (ID) of the newly created author
        return entity.Id;                              
    }
}