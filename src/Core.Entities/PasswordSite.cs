using System;

namespace Core.Entities
{
    public class PasswordSite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string NameSite { get; set; }
        public string URLSite { get; set; }
        public string DescriptionSite { get; set; }
        public string UserNameSite { get; set; }
        public string Password { get; set; }
        public string SecretAnswer { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
