using Core.Entities;
using Core.V1.Account.ConfirmAccount.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.Account.ConfirmAccount
{
    public class ConfirmAccountRequestHandler : IRequestHandler<ConfirmAccountRequest>
    {
        private readonly UserManager<User> userManager;

        public ConfirmAccountRequestHandler(UserManager<User> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<Unit> Handle(ConfirmAccountRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotExistentUserException();
            }

            user.EmailConfirmed = true;

            var result = await userManager.ConfirmEmailAsync(user, request.Token);

            if (!result.Succeeded)
            {
                throw new CannotConfirmAccountException();
            }

            return Unit.Value;
        }
    }
}
