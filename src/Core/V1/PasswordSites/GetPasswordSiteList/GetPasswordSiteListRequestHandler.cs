using Core.Data.Repositories;
using Core.Entities;
using Core.V1.PasswordSites.GetPasswordSiteList.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Core.Data;
using System.Collections.Immutable;

namespace Core.V1.PasswordSites.GetPasswordSiteList
{
    public class GetPasswordSiteListRequestHandler : IRequestHandler<GetPasswordSiteListRequest, PagedResults<PasswordSiteModel>>
    {
        private readonly UserManager<User> userManager;
        private readonly IPasswordSiteRepository passwordSiteRepository;

        public GetPasswordSiteListRequestHandler(UserManager<User> userManager, IPasswordSiteRepository passwordSiteRepository)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.passwordSiteRepository = passwordSiteRepository ?? throw new ArgumentNullException(nameof(passwordSiteRepository));
        }

        public async Task<PagedResults<PasswordSiteModel>> Handle(GetPasswordSiteListRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.GetUserName());
            var totalPasswordList = await passwordSiteRepository.GetAllPasswordsCount(user.Id, request.SearchValue);
            var passwordList = await passwordSiteRepository.GetAllPasswords(user.Id, request.SearchValue, request.SortParams, request.PageParams);

            var passwordSiteModelList = passwordList.Select(x => new PasswordSiteModel()
            {
                NameSite = x.NameSite,
                Password = x.Password,
                UserNameSite = x.UserNameSite,
                PasswordSiteId = x.Id
            });

            var inmutableList = ImmutableList.CreateRange(passwordSiteModelList);

            return PagedResults.Create(inmutableList, totalPasswordList);
        }
    }
}
