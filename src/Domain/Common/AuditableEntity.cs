using System;

namespace Hiro.Core.Domain.Common
{
    public abstract class AuditableEntity<TId> : Entity<TId>
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
