using Core.Entities;
using Core.Shared.Configuration;
using Core.Shared.Services;
using Core.V1.Account.ConfirmAccount.Exceptions;
using Core.V1.Account.Reset.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.Account.Reset
{
    public class ResetPasswordRequestHandler : IRequestHandler<ResetPasswordRequest>
    {
        private readonly UserManager<User> userManager;
        private readonly IMailingService mailingService;
        private readonly FrontendOptions frontendOptions;

        public ResetPasswordRequestHandler(
            UserManager<User> userManager,
            IMailingService mailingService,
            FrontendOptions frontendOptions)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
            this.frontendOptions = frontendOptions ?? throw new ArgumentNullException(nameof(frontendOptions));
        }

        public async Task<Unit> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotExistentUserException();
            }

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var model = MailModel.Create(
                "Recupero de contraseña",
                new ResetPasswordEmailData(token, $"{frontendOptions.Url}{frontendOptions.ForgotPassword}"));

            await mailingService.SendEmailAsync(
                user.Email, model.Subject, await request.GetEmailBody(model));

            return Unit.Value;
        }
    }
}
