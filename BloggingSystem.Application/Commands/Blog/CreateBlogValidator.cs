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
        RuleFor(b => b.Name).NotEmpty();
        RuleFor(b => b.Url).NotEmpty().Must(url => Uri.TryCreate(url, UriKind.Absolute, out _));
    }
}