using Hiro.Core.Application.Usuarios.Commands.AlterarSenha;
using Hiro.Core.Application.Usuarios.Commands.CriarUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hiro.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : BaseController
    {
        /// <summary>
        /// Cria um usuário vinculado a um colaborador do sistema
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> Post([FromBody] CreateUserDto usuario)
        {

            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.Username))
            {
                var command = new CreateUserCommand(usuario);
                await Mediator.Send(command);
                return Created("api/Users", usuario);
            }
            return Ok();
        }

        /// <summary>
        /// Redefine a senha de um usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<object> ChangePassword([FromBody] AlterarSenhaDto request)
        {
            var command = new ChangePasswordCommand(request);
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
