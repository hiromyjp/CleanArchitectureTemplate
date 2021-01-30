using Microsoft.EntityFrameworkCore;

namespace Hiro.Infrastructure.Identity.Context
{
    public class ApplicationIdentityDbContextFactory : DesignTimeDbContextFactoryBase<UsersDbContext>
    {
        protected override UsersDbContext CreateNewInstance(DbContextOptions<UsersDbContext> options)
        {
            return new UsersDbContext(options);
        }
    }
}
