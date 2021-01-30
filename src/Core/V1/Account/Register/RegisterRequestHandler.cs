using Core.Entities;
using Core.V1.Account.Register.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.Account.Register
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest>
    {
        private readonly UserManager<User> userManager;

        public RegisterRequestHandler(UserManager<User> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<Unit> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var user = new User(request.UserName)
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedOn = DateTime.Now,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new CannotRegisterAccountException(result.Errors);
            }

            return Unit.Value;
        }
    }
}
