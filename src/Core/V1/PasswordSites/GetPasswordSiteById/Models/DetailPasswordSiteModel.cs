
namespace Core.V1.PasswordSites.GetPasswordSiteById.Models
{
    public class DetailPasswordSiteModel
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
