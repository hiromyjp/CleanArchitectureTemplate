using Hiro.Core.Domain.Entities;
using System.Linq;

namespace Hiro.Infrastructure.Persistence
{
    class ApplicationDbContextSeedTestData
    {

        public static void SeedWarehouses(ApplicationDbContext dbContext)
        {
            if (dbContext.Warehouses.Count() == 0)
            {
                var warehouse = new Warehouse("Main Warehouse", 1);
                dbContext.Warehouses.Add(warehouse);
                dbContext.SaveChanges();
            }
        }

    }
}
