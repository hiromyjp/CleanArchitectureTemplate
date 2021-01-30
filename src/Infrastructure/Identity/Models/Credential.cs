using Hiro.Core.Application.Common.Interfaces;
using System;

namespace Hiro.Infrastructure.Identity.Models
{
    public class Credential : IUserCredential
    {
        protected Credential()
        {
        }

        public Credential(string email, string senha)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
