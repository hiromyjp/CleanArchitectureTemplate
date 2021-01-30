using Hiro.Core.Application.Common.Interfaces;
using Hiro.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Hiro.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManagerService>();
            return services;
        }
    }
}
