using Core.Data.Repositories;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.PasswordSites.CreatePasswordSite
{
    public class CreatePasswordSiteRequestHandler : IRequestHandler<CreatePasswordSiteRequest>
    {
        private readonly UserManager<User> userManager;
        private readonly IPasswordSiteRepository passwordSiteRepository;

        public CreatePasswordSiteRequestHandler(UserManager<User> userManager, IPasswordSiteRepository passwordSiteRepository)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.passwordSiteRepository = passwordSiteRepository ?? throw new ArgumentNullException(nameof(passwordSiteRepository));
        }

        public async Task<Unit> Handle(CreatePasswordSiteRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.GetUserName());

            var newPasswordSite = new PasswordSite()
            {
                UserId = user.Id,
                NameSite = request.NameSite,
                URLSite = request.UrlSite,
                UserNameSite = request.UserNameSite,
                Password = request.Password,
                SecretAnswer = request.SecretAnswer,
                DescriptionSite = request.DescriptionSite,
                CreatedOn = DateTime.Now
            };

            passwordSiteRepository.Add(newPasswordSite);

            return Unit.Value;
        }
    }
}
