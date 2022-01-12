using BookmarkManager.Application.Dto;

using MediatR;

using System.Collections.Generic;

namespace BookmarkManager.Application.Features
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
        //TODO :Add PageIndex and PageSize
        public GetCategoriesQuery()
        {
        }
    }
}
