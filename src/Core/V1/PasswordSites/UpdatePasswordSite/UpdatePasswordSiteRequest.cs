using Core.Shared;
using MediatR;

namespace Core.V1.PasswordSites.UpdatePasswordSite
{
    public class UpdatePasswordSiteRequest : LoggedRequest, IRequest
    {
        public int PasswordSiteId { get; set; }
        public string NameSite { get; set; }
        public string UrlSite { get; set; }
        public string DescriptionSite { get; set; }
        public string UserNameSite { get; set; }
        public string Password { get; set; }
        public string SecretAnswer { get; set; }
    }
}
