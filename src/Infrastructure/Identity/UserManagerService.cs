using Hiro.Core.Application.Common;
using Hiro.Core.Application.Common.Interfaces;
using Hiro.Core.Application.Common.Models;
using Hiro.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hiro.Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public UserManagerService(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, TokenConfigurations tokenConfigurations, 
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory, 
            IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenConfigurations = tokenConfigurations;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
        }
        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, 
            string password, string initialRole = UserRoles.ROLE_USER)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded && !string.IsNullOrWhiteSpace(initialRole))
            {
                _userManager.AddToRoleAsync(user, initialRole).Wait();
            }
            return (result.ToApplicationResult(), user.Id);

        }


        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<ILoginResult> LoginAsync(IUserCredential credential)
        {
            var user = await _userManager.FindByEmailAsync(credential.Email);
            if (user != null)
            {
                // Efetua o login com base no Id do usuário e sua senha
                var resultadoLogin = _signInManager
                    .CheckPasswordSignInAsync(user, credential.Senha, false)
                    .Result;
                if (resultadoLogin.Succeeded)
                {
                    // Busca as roles do usuário
                    var roles = await _userManager.GetRolesAsync(user);
                    var token = await GenerateTokenAsync(user, roles);
                    return LoginResult.Succedded(credential, roles, token);
                }
            }
            return LoginResult.Failed(credential);

        }

        private async Task<string> GenerateTokenAsync(ApplicationUser user, IList<string> roles)
        {
            IdentityOptions options = new IdentityOptions();

            var claims = new List<Claim>(){
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(options.ClaimsIdentity.RoleClaimType, role));
            }

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Email, "Login"),
                claims
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromHours(_tokenConfigurations.Hours);

            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenConfigurations.Key);
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            return handler.WriteToken(securityToken);
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);
            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        public async Task<bool> ResetPasswordAsync(string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);
            return user.UserName;
        }
    }
}
