using System;

namespace Core.V1.Account.Reset.Models
{
    public class ResetPasswordEmailData
    {
        public ResetPasswordEmailData(string token, string forgotPasswordUrl)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
            ForgotPasswordUrl = forgotPasswordUrl;
        }

        public string Token { get; set; }
        public string ForgotPasswordUrl { get; }
    }
}
