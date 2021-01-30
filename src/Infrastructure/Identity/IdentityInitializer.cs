using Hiro.Core.Application.Common;
using Hiro.Infrastructure.Identity.Context;
using Hiro.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace Hiro.Infrastructure.Identity
{
    /// <summary>
    /// Popula a base de usuários com dados de teste e cria as Roles do sistema
    /// </summary>
    public class IdentityInitializer
    {
        private readonly UsersDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public IdentityInitializer(
            UsersDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (!_roleManager.RoleExistsAsync(UserRoles.ROLE_USER).Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new IdentityRole(UserRoles.ROLE_USER)).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role {UserRoles.ROLE_USER}.");
                }
            }
            if (!_roleManager.RoleExistsAsync(UserRoles.ROLE_ADMIN).Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new IdentityRole(UserRoles.ROLE_ADMIN)).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role {UserRoles.ROLE_ADMIN}.");
                }
            }

            CreateUser(
                new ApplicationUser()
                {
                    UserName = "admin@hiro.com.br",
                    Email = "admin@hiro.com.br",
                    EmailConfirmed = true,
                    PhoneNumber = "23232323",
                }, "Hiro@2020", UserRoles.ROLE_ADMIN);

            CreateUser(
                new ApplicationUser()
                {
                    UserName = "operador1@hiro.com.br",
                    Email = "operador1@hiro.com.br",
                    EmailConfirmed = true,
                    PhoneNumber = "23232323",
                }, "Hiro@2020", UserRoles.ROLE_USER);

            CreateUser(
                new ApplicationUser()
                {
                    UserName = "operador2@hiro.com.br",
                    Email = "operador2@hiro.com.br",
                    EmailConfirmed = true,
                    PhoneNumber = "23232323",
                }, "Hiro@2020", UserRoles.ROLE_USER);
        }

        private void CreateUser(
            ApplicationUser user,
            string password,
            string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !string.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}
