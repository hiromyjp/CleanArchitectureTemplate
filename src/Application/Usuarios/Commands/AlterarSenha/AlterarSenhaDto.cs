using System;

namespace Hiro.Core.Application.Usuarios.Commands.AlterarSenha
{
    public class AlterarSenhaDto
    {
        public Guid ColaboradorId { get; set; }
        public string NovaSenha { get; set; }
    }
}
