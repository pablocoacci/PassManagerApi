using Core.Entities;
using Core.V1.Account.Login.Exceptions;
using Core.V1.Account.Login.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.Account.Login
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginModel>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public LoginRequestHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task<LoginModel> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.Email);

            if (user == null || !user.EmailConfirmed)
            {
                throw new InvalidUsernameOrPasswordException();
            }

            var claims = new List<Claim>();
            claims.AddRange(await userManager.GetClaimsAsync(user));

            var roles = await userManager.GetRolesAsync(user);
            foreach (var roleId in roles)
            {
                var role = await roleManager.FindByIdAsync(roleId);
                claims.Add(new Claim(ClaimTypes.Role, role.Id));
                claims.AddRange(await roleManager.GetClaimsAsync(role));
            }

            var isValidPassword = await userManager.CheckPasswordAsync(user, request.Password);
            if (!isValidPassword)
            {
                await userManager.AccessFailedAsync(user);
                throw new InvalidUsernameOrPasswordException();
            }

            await userManager.ResetAccessFailedCountAsync(user);

            var response = new LoginModel(user.Id, claims.ToImmutableList());

            return response;
        }
    }
}
