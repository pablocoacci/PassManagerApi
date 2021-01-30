using Core.Entities;
using Core.V1.Account.ChangePassword.Exceptions;
using Core.V1.Account.ConfirmAccount.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.Account.ChangePassword
{
    public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequest>
    {
        private readonly UserManager<User> userManager;

        public ChangePasswordRequestHandler(UserManager<User> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<Unit> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotExistentUserException();
            }

            var isSamePassword = await userManager.CheckPasswordAsync(user, request.Password);

            if (isSamePassword)
            {
                throw new DoNotMeetPreestablishedParametersException();
            }

            var result = await userManager.ResetPasswordAsync(user, request.Token, request.Password);

            if (!result.Succeeded)
            {
                throw new CannotResetPasswordException();
            }

            return Unit.Value;
        }
    }
}
