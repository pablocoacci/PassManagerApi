using Core.Shared.Services;
using MailKit;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Core.Services.Mailing
{
    public class MailingService : IMailingService
    {
        private readonly IMailTransport client;
        private readonly MailingServiceOptions options;

        public MailingService(IMailTransport client, MailingServiceOptions options)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await ConnectAsync(client);

            await client.SendAsync(BuildMail(email, subject, htmlMessage));

            await DisconnectAsync(client);
        }

        private static Task DisconnectAsync(IMailTransport client)
        {
            return client.DisconnectAsync(true);
        }

        private async Task ConnectAsync(IMailTransport client)
        {
            await client.ConnectAsync(
                                host: options.Smtp.Host,
                                port: options.Smtp.Port,
                                useSsl: false);

            //Note: only needed if the SMTP server requires authentication
            if (!string.IsNullOrWhiteSpace(options.Smtp.Username)
                && !string.IsNullOrWhiteSpace(options.Smtp.Password))
            {
                await client.AuthenticateAsync(
                    userName: options.Smtp.Username,
                    password: options.Smtp.Password);
            }
        }

        private MimeMessage BuildMail(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage()
            {
                Subject = subject
            };
            message.From.Add(new MailboxAddress(options.From.Name, options.From.Address));
            message.To.Add(new MailboxAddress(email));
            message.Body = BuildMailBody(htmlMessage);
            return message;
        }

        private MimeEntity BuildMailBody(string htmlMessage)
        {
            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = htmlMessage
            };

            return bodyBuilder.ToMessageBody();
        }
    }
}
