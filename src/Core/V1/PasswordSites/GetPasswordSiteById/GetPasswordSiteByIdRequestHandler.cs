using Core.Data.Repositories;
using Core.Entities;
using Core.V1.PasswordSites.GetPasswordSiteById.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.PasswordSites.GetPasswordSiteById
{
    public class GetPasswordSiteByIdRequestHandler : IRequestHandler<GetPasswordSiteByIdRequest, DetailPasswordSiteModel>
    {
        private readonly UserManager<User> userManager;
        private readonly IPasswordSiteRepository passwordSiteRepository;

        public GetPasswordSiteByIdRequestHandler(UserManager<User> userManager, IPasswordSiteRepository passwordSiteRepository)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.passwordSiteRepository = passwordSiteRepository ?? throw new ArgumentNullException(nameof(passwordSiteRepository));
        }

        public async Task<DetailPasswordSiteModel> Handle(GetPasswordSiteByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.GetUserName());
            var passwordSite = await passwordSiteRepository.GetPasswordSiteById(user.Id, request.PasswordSiteId);

            return new DetailPasswordSiteModel()
            {
                PasswordSiteId = passwordSite.Id,
                DescriptionSite = passwordSite.DescriptionSite,
                NameSite = passwordSite.NameSite,
                Password = passwordSite.Password,
                SecretAnswer = passwordSite.SecretAnswer,
                UrlSite = passwordSite.URLSite,
                UserNameSite = passwordSite.UserNameSite
            };
        }
    }
}
