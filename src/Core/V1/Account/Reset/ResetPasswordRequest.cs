using Core.Shared.Services;
using Core.V1.Account.Reset.Models;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Core.V1.Account.Reset
{
    public class ResetPasswordRequest : IRequest
    {
        public string Email { get; set; }

        private Func<MailModel<ResetPasswordEmailData>, Task<string>> emailBodyBuilder;

        public void SetEmailBodyBuilder(Func<MailModel<ResetPasswordEmailData>, Task<string>> func)
        {
            emailBodyBuilder = func;
        }

        public Task<string> GetEmailBody(MailModel<ResetPasswordEmailData> mailModel)
        {
            return emailBodyBuilder(mailModel);
        }
    }
}
