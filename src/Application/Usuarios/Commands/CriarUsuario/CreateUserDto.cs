using System;

namespace Hiro.Core.Application.Usuarios.Commands.CriarUsuario
{
    public class CreateUserDto
    {
        public Guid ColaboradorId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
