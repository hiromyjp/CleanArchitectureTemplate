using Hiro.Infrastructure.Persistence;

namespace Hiro.Infrastructure.Persistence
{
    class ApplicationDbContextSeedTestData
    {

        public static void SeedDepositos(ApplicationDbContext dbContext)
        {
            //if (dbContext.Depositos.Count() == 0)
            //{
            //    dbContext.Fazendas.ToList().ForEach(f =>
            //    {
            //        var deposito = new Deposito()
            //        {
            //            Id = Guid.NewGuid(),
            //            Nome = "Deposito " + f.Nome,
            //            CodigoParceiro = "Deposito " + f.Nome,
            //        };
            //        dbContext.Depositos.Add(deposito);
            //    });
            //    dbContext.SaveChanges();
            //}
        }

    }
}
