using Hiro.Core.Domain.Common;
using System;

namespace Hiro.Core.Domain.Entities
{
    public class Deposito : Entity<Guid>
    {
        protected Deposito()
        {
            Id = Guid.NewGuid();
        }

        public Deposito(string nome, string codigoParceiro, int filialId)
            : this()
        {
            Nome = nome;
            CodigoParceiro = codigoParceiro;
            FilialId = filialId;
        }

        public string Nome { get; set; }
        public string CodigoParceiro { get; set; }
        public int FilialId { get; set; }
    }
}
