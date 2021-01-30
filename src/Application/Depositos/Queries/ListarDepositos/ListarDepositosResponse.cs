using System.Collections.Generic;

namespace Hiro.Core.Application.Depositos.Queries.ListarDepositos
{
    public class ListarDepositosResponse
    {
        public ListarDepositosResponse()
        {
            Depositos = new List<DepositoDto>();
        }

        public IList<DepositoDto> Depositos { get; set; }
        public int Count => Depositos.Count;
    }
}
