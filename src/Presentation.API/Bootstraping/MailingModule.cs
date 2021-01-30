using Autofac;
using Core.Services.Mailing;
using Core.Shared.Services;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;

namespace Presentation.API.Bootstraping
{
    public class MailingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                .Register(MailTransportFactory)
                .As<IMailTransport>()
                .InstancePerLifetimeScope();

            builder
                .Register(MailingServiceOptionsFactory)
                .AsSelf()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<MailingService>()
                .As<IMailingService>()
                .InstancePerLifetimeScope();
        }

        private MailingServiceOptions MailingServiceOptionsFactory(IComponentContext ctx)
        {
            var config = ctx.Resolve<IConfiguration>();
            return new MailingServiceOptions(
                new MailingServiceSmtpOptions(
                    config["MailingServiceOptions:Smtp:Host"],
                    int.Parse(config["MailingServiceOptions:Smtp:Port"]),
                    config["MailingServiceOptions:Smtp:Username"],
                    config["MailingServiceOptions:Smtp:Password"]),
                new MailingServiceFromOptions(
                    config["MailingServiceOptions:From:Name"],
                    config["MailingServiceOptions:From:Address"]));
        }

        private IMailTransport MailTransportFactory(IComponentContext ctx)
        {
            return new SmtpClient
            {
                ServerCertificateValidationCallback = (s, c, h, e) => true
            };
        }
    }
}
