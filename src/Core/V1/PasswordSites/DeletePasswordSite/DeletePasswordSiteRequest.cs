using Core.Shared;
using MediatR;

namespace Core.V1.PasswordSites.DeletePasswordSite
{
    public class DeletePasswordSiteRequest : LoggedRequest, IRequest
    {
        public int PasswordSiteId { get; set; }
    }
}
