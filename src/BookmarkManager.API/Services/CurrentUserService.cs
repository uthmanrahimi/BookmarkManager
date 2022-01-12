using BookmarkManager.Application.Interfaces;

using Microsoft.AspNetCore.Http;

namespace BookmarkManager.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId =>1; // in a real world application, this fetch from Claim or Header
    }
}
