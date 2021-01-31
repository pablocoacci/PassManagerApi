using Core.Data.Repositories;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.PasswordSites.DeletePasswordSite
{
    public class DeletePasswordSiteRequestHandler : IRequestHandler<DeletePasswordSiteRequest>
    {
        private readonly UserManager<User> userManager;
        private readonly IPasswordSiteRepository passwordSiteRepository;

        public DeletePasswordSiteRequestHandler(UserManager<User> userManager, IPasswordSiteRepository passwordSiteRepository)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.passwordSiteRepository = passwordSiteRepository ?? throw new ArgumentNullException(nameof(passwordSiteRepository));
        }

        public async Task<Unit> Handle(DeletePasswordSiteRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.GetUserName());
            var passwordSite = await passwordSiteRepository.GetPasswordSiteById(user.Id, request.PasswordSiteId);

            passwordSiteRepository.Delete(passwordSite);

            return Unit.Value;
        }
    }
}
