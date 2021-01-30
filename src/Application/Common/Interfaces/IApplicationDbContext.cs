using Hiro.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Hiro.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Deposito> Depositos { get; set; }


        //DbSet<>

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
