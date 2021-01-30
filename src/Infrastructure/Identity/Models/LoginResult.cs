using Hiro.Core.Application.Common.Interfaces;
using System.Collections.Generic;

namespace Hiro.Infrastructure.Identity.Models
{
    public class LoginResult : ILoginResult
    {
        //Failed login result
        private LoginResult(IUserCredential userCredential)
        {
            Succeeded = false;
            UserCredential = userCredential;
        }

        //Succedded login result
        private LoginResult(IUserCredential userCredential, IList<string> roles, string token)
        {
            Succeeded = true;
            Roles = roles;
            UserCredential = userCredential;
            Token = token;
        }


        public bool Succeeded { get; }

        public string Token { get; }

        public IList<string> Roles { get; }

        public IUserCredential UserCredential { get; }

        public static LoginResult Failed(IUserCredential userCredential)
        {
            return new LoginResult(userCredential);
        }

        public static LoginResult Succedded(IUserCredential userCredential, IList<string> roles, string token)
        {
            return new LoginResult(userCredential, roles, token);
        }
    }
}
