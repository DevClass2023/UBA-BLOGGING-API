using AutoMapper;
using MediatR;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Application.DTOs;
using BloggingSystem.Domain.Entities; 

namespace BloggingSystem.Application.Commands.Author;

public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, Guid>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateAuthorHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        
        var entity = _mapper.Map<BloggingSystem.Domain.Entities.Author>(request.Dto);

        await _uow.Authors.AddAsync(entity);
        await _uow.SaveChangesAsync();
        return entity.Id;
    }
}