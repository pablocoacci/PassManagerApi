using Core.Data.Repositories;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.PasswordSites.UpdatePasswordSite
{
    public class UpdatePasswordSiteRequestHandler : IRequestHandler<UpdatePasswordSiteRequest>
    {
        private readonly UserManager<User> userManager;
        private readonly IPasswordSiteRepository passwordSiteRepository;

        public UpdatePasswordSiteRequestHandler(UserManager<User> userManager, IPasswordSiteRepository passwordSiteRepository)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.passwordSiteRepository = passwordSiteRepository ?? throw new ArgumentNullException(nameof(passwordSiteRepository));
        }

        public async Task<Unit> Handle(UpdatePasswordSiteRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.GetUserName());
            var passwordSite = await passwordSiteRepository.GetPasswordSiteById(user.Id, request.PasswordSiteId);

            passwordSite.NameSite = request.NameSite;
            passwordSite.URLSite = request.UrlSite;
            passwordSite.UserNameSite = request.UserNameSite;
            passwordSite.Password = request.Password;
            passwordSite.SecretAnswer = request.SecretAnswer;
            passwordSite.DescriptionSite = request.DescriptionSite;
            passwordSite.UpdatedOn = DateTime.Now;

            passwordSiteRepository.Update(passwordSite);

            return Unit.Value;
        }
    }
}
