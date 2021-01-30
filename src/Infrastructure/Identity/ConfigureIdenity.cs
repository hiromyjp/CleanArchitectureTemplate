using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hiro.Infrastructure.Identity.Context;

namespace Hiro.Infrastructure.Identity
{
    public static class ConfigureIdenity
    {
        public static IServiceCollection IdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurando o uso da classe de contexto para
            // acesso às tabelas do ASP.NET Identity Core
            services.AddDbContext<UsersDbContext>(options =>
            //options.UseInMemoryDatabase("IdentityDB")
            //.UseLazyLoadingProxies());
            options.UseSqlServer(configuration.GetConnectionString("IdentityDbConnection"),
                options => options.EnableRetryOnFailure()).EnableDetailedErrors());



            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });

            return services;
        }
    }
}
