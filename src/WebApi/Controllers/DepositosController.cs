using System.Threading.Tasks;
using Hiro.Core.Application.Depositos.Queries.ListarDepositos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hiro.Presentation.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class DepositosController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ListarDepositosResponse>> GetAll()
        {
            var vm = await Mediator.Send(new ListarDepositosQuery());

            return Ok(vm);
        }
    }
}
