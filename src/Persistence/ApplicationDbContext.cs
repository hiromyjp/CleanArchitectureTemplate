using Hiro.Core.Application.Common.Interfaces;
using Hiro.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hiro.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ApplicationDbContextSeedTestData.SeedWarehouses(this);
        }

        public DbSet<Warehouse> Warehouses { get; set; }


        /// <summary>
        /// Aplica configurações de mapeamento
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
