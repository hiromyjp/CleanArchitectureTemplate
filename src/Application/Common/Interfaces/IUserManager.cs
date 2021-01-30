using Hiro.Core.Application.Common.Models;
using System.Threading.Tasks;

namespace Hiro.Core.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password, string initialRole);

        Task<Result> DeleteUserAsync(string userId);
        Task<ILoginResult> LoginAsync(IUserCredential credential);
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<bool> ResetPasswordAsync(string userId, string newPassword);
        Task<string> GetUserNameAsync(string userId);
    }
}
