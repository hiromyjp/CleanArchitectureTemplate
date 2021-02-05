using System.Threading.Tasks;
using Hiro.Core.Application.Warehouses.Queries.ListWarehouses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hiro.Presentation.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class WarehouseController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ListWarehousesResponse>> GetAll()
        {
            var vm = await Mediator.Send(new ListWarehousesQuery());

            return Ok(vm);
        }
    }
}
