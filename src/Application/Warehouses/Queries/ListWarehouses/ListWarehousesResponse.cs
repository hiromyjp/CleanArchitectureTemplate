using System.Collections.Generic;

namespace Hiro.Core.Application.Warehouses.Queries.ListWarehouses
{
    public class ListWarehousesResponse
    {
        public ListWarehousesResponse()
        {
            Warehouses = new List<WarehouseDto>();
        }

        public IList<WarehouseDto> Warehouses { get; set; }
        public int Count => Warehouses.Count;
    }
}
