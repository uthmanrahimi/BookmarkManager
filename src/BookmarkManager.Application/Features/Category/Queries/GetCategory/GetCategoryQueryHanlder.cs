using AutoMapper;

using BookmarkManager.Application.Common.Exceptions;
using BookmarkManager.Application.Dto;
using BookmarkManager.Application.Interfaces;

using MediatR;

using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Features
{
    public class GetCategoryQueryHanlder : IRequestHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryQueryHanlder(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FindAsync(request.Id);
            if (category == null)
                throw new RestException(HttpStatusCode.NotFound, $"Category with given ID ({request.Id}) does not exist.");
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
