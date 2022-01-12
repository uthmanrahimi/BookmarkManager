using BookmarkManager.Application.Interfaces;
using BookmarkManager.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace BookmarkManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("bookmarkmg"));
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"),
                            m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            return services;

        }
    }
}
