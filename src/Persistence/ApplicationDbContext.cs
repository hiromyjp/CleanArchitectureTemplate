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
            ApplicationDbContextSeedTestData.SeedDepositos(this);
        }

        public DbSet<Deposito> Depositos { get; set; }


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
