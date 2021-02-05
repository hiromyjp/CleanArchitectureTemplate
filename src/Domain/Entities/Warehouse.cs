using Hiro.Core.Domain.Common;
using System;

namespace Hiro.Core.Domain.Entities
{
    public class Warehouse : Entity<Guid>
    {
        protected Warehouse()
        {
            Id = Guid.NewGuid();
        }

        public Warehouse(string name, int branchId)
            : this()
        {
            Name = name;
            BranchId = branchId;
        }

        public string Name { get; set; }
        public int BranchId { get; set; }
    }
}
