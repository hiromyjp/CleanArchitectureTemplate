using System.Collections.Generic;
using System.Security.Claims;

namespace Hiro.Core.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAuthenticated { get; }

        IEnumerable<Claim> Claims { get; }

        IEnumerable<string> Roles { get; }
    }
}
