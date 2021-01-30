using Hiro.Core.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Hiro.Presentation.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
            Claims = httpContextAccessor.HttpContext?.User?.Claims;
            Roles = Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
        }

        public string UserId { get; }

        public bool IsAuthenticated { get; }

        public IEnumerable<Claim> Claims { get; }

        public IEnumerable<string> Roles { get; }
    }
}
