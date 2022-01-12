using AutoMapper;

using BookmarkManager.Application.Dto;
using BookmarkManager.Application.Interfaces;
using BookmarkManager.Domain.Entities;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Features
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<CategoryEntity>(request);
            await _dbContext.Categories.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
