using System.Collections.Generic;

namespace Hiro.Core.Application.Common.Interfaces
{
    public interface ILoginResult
    {
        bool Succeeded { get; }
        string Token { get; }
        IList<string> Roles { get; }
        IUserCredential UserCredential { get; }
    }
}
