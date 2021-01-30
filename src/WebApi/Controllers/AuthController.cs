using System.Threading.Tasks;
using Hiro.Core.Application.Common.Interfaces;
using Hiro.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hiro.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Post(
            [FromBody] Credential usuario,
            [FromServices] IUserManager userManager)
        {
            if (usuario != null && !string.IsNullOrWhiteSpace(usuario.Email))
            {
                var loginResult = await userManager.LoginAsync(new Credential(usuario.Email, usuario.Senha));
                if (loginResult.Succeeded)
                {
                    return loginResult.Token;
                }
            }
            return Unauthorized(new
            {
                authenticated = false,
                message = "Incorrect username and/or password."
            });
        }
    }
}
