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
        private static readonly Random random = new Random(1);
        private readonly UserManager<User> userManager;

        public RegisterRequestHandler(UserManager<User> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<Unit> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var user = new User(request.Email);

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new CannotRegisterAccountException(result.Errors);
            }

            return Unit.Value;
        }
    }
}
