using Core.Shared;
using Core.V1.PasswordSites.GetPasswordSiteById.Models;
using MediatR;

namespace Core.V1.PasswordSites.GetPasswordSiteById
{
    public class GetPasswordSiteByIdRequest : LoggedRequest, IRequest<DetailPasswordSiteModel>
    {
        public int PasswordSiteId { get; set; }
    }
}
