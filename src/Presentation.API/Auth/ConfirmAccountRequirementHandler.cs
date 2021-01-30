using Core.V1.Account.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Presentation.API.Helpers.Extensions;
using System;
using System.Threading.Tasks;

namespace Presentation.API.Auth
{
    public class ConfirmAccountRequirementHandler : AuthorizationHandler<ConfirmAccountRequirement>
    {
        private readonly IMediator mediator;

        public ConfirmAccountRequirementHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ConfirmAccountRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                return;
            }

            var request = new GetAccountRequest();
            request.SetUserName(context.User.UserName());
            var response = await mediator.Send(request);

            if (response.EmailConfirmed)
            {
                context.Succeed(requirement);
            }
        }
    }
}
