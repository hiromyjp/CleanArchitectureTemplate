namespace Hiro.Core.Domain.Common
{
    public abstract class Entity<TId>
    {
        public TId Id { get; set; }
    }
}
