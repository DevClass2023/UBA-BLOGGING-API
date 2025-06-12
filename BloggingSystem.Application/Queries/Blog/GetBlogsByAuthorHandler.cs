
using MediatR;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks; 
using BloggingSystem.Application.Exceptions; 
using BloggingSystem.Application.DTOs.Blog; 
using BloggingSystem.Domain.Interfaces; 

namespace BloggingSystem.Application.Queries.Blog
{
    public class GetBlogsByAuthorHandler : IRequestHandler<GetBlogsByAuthorQuery, List<BlogDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetBlogsByAuthorHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<BlogDto>> Handle(GetBlogsByAuthorQuery request, CancellationToken cancellationToken)
        {
        
            // If the repository method GetByAuthorIdAsync returns an empty list for non-existent authors, this check might be redundant.
            var authorExists = await _uow.Authors.GetByIdAsync(request.AuthorId);
            if (authorExists == null)
            {
                throw new NotFoundException($"Author with ID {request.AuthorId} not found.");
            }

            var blogs = await _uow.Blogs.GetByAuthorIdAsync(request.AuthorId);

            // If no blogs are found for the author, an empty list will be mapped and returned, which is generally acceptable for "List" queries.
            return _mapper.Map<List<BlogDto>>(blogs);
        }
    }
}